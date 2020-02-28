using System;
using System.Collections.Generic;
using MoneyAdmin.Domain.Core.Models;

namespace MoneyAdmin.Domain.Models
{
    public abstract class Transaction : Entity
    {
        protected Transaction(string name, string details, DateTime dueDate, Category category, Account account)
        {
            Name = name;
            Details = details;
            DueDate = dueDate;
            Category = category;
            Account = account;
            Payments = new List<Payment>();
        }

        public string Name { get; set; }
        public string Details { get; set; }
        public DateTime DueDate { get; set; }
        public Category Category { get; set; }
        public Account Account { get; set; }
        public ICollection<Payment> Payments { get; set; }

        public abstract void SetPayment(decimal value);
    }
}
