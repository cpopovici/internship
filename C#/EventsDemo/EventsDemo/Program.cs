using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EventsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var account = new BankAccount();
            var user = new User(account);
            var superUser = new SuperUser(account);

            //WeakEventManager<BankAccount, AccountEventArgs>.AddHandler(account, "OnDeposit", user.SendEmailNotification);
            //WeakEventManager<BankAccount, AccountEventArgs>.AddHandler(account, "OnWithdraw", user.SendEmailNotification);

            //WeakEventManager<BankAccount, AccountEventArgs>.AddHandler(account, "OnDeposit", superUser.SendEmailNotification);
            //WeakEventManager<BankAccount, AccountEventArgs>.AddHandler(account, "OnDeposit", superUser.SendMobileNotification);
            //WeakEventManager<BankAccount, AccountEventArgs>.AddHandler(account, "OnWithdraw", superUser.SendMobileNotification);

            account.Deposit(100);
            account.Withdraw(50);
            //superUser.Unregister(account);
            //account.Withdraw(50);
            Console.ReadLine();
        }

       
    }
}
