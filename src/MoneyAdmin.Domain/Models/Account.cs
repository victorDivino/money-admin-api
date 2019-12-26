using MoneyAdmin.Domain.Core.Models;
using System;

namespace MoneyAdmin.Domain
{
    public class Account : Entity
    {
        public Account(string name, decimal initialValue = 0)
        {
            Id = Guid.NewGuid();
            Name = name;
            Amount = initialValue;
        }

        protected Account() { }

        public string Name { get; set; }

        public decimal Amount { get; set; }
    }
}
