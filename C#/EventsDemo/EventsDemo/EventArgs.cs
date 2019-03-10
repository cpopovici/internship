using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsDemo
{
    public class AccountEventArgs : EventArgs
    {
        public string Message { get; }
        public int Sum { get; }
        public int Balance { get; }
        public DateTime Date;

        public AccountEventArgs(string message, int sum, int balance, DateTime date)
        {
            this.Message = message;
            this.Sum = sum;
            this.Date = date;
            this.Balance = balance;
        }
    }
}
