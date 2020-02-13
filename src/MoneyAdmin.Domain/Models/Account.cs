using MoneyAdmin.Domain.Core.Models;

namespace MoneyAdmin.Domain
{
    public class Account : Entity
    {
        public Account(string name, decimal initialValue = 0)
        {
            Name = name;
            Amount = initialValue;
        }

        protected Account() { }

        public string Name { get; set; }

        public decimal Amount { get; set; }
    }
}
