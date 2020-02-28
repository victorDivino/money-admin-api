using System;
using MoneyAdmin.Domain.Core.Models;

namespace MoneyAdmin.Domain
{
    public sealed class Account : Entity
    {
        public Account(string name, decimal initialValue = 0)
        {
            Id = Guid.NewGuid();
            Name = name;
            Amount = initialValue;
        }

        private Account() { }

        public string Name { get; set; }

        public decimal Amount { get; set; }
    }
}
