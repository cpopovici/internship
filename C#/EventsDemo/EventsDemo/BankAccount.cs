using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsDemo
{
    class BankAccount
    {
        public event EventHandler<AccountEventArgs> OnDeposit;
        public event EventHandler<AccountEventArgs> OnWithdraw;
      
        private int _amount;
        public int Amount
        {
            get { return _amount; }
            private set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException();   
                _amount = value;
            }
        }

        public void Deposit(int sum)
        {
            this.Amount += sum;

            var eventArgs = new AccountEventArgs($"Deposited on account {sum}$", sum, Amount, DateTime.Now);
            OnDeposit?.Invoke(this, eventArgs);   
        }

        public void Withdraw(int sum)
        {
            this.Amount -= sum;

            var eventArgs = new AccountEventArgs($"Withdraw from account {sum}$", sum, Amount, DateTime.Now);
            OnWithdraw?.Invoke(this, eventArgs);
        }

    }

    class User
    {
        public User(BankAccount account)
        {
            account.OnDeposit += SendEmailNotification;
            account.OnWithdraw += SendEmailNotification;
        }

        public void SendEmailNotification(object sender, AccountEventArgs e)
        {
            Console.WriteLine("Send Email Notification to User:");
            Console.WriteLine("  {0}\n  New balance: {1}$\n  Date: {2}\n", e.Message, e.Balance, e.Date);
        }

        public void Unregister(BankAccount account)
        {
            account.OnDeposit -= SendEmailNotification;
            account.OnWithdraw -= SendEmailNotification;
        }
    }

    class SuperUser
    {
        public SuperUser(BankAccount account)
        {
            account.OnDeposit += SendEmailNotification;
            account.OnDeposit += SendMobileNotification;
            account.OnWithdraw += SendMobileNotification;
        }

        public void SendEmailNotification(object sender, AccountEventArgs e)
        {
            Console.WriteLine("Send Email Notification to Super User:");
            Console.WriteLine("  {0}\n  New balance: {1}$\n  Date: {2}\n", e.Message, e.Balance, e.Date);
        }

        public void SendMobileNotification(object sender, AccountEventArgs e)
        {
            Console.WriteLine("Send Mobile SMS Notification to Super User:");
            Console.WriteLine("  {0}\n  New balance: {1}$\n  Date: {2}\n", e.Message, e.Balance, e.Date);
        }

        public void Unregister(BankAccount account)
        {
            account.OnDeposit -= SendEmailNotification;
            account.OnDeposit -= SendMobileNotification;
            account.OnWithdraw -= SendMobileNotification;
        }
    }
}
