using System;
using MoneyAdmin.Domain.Core.Models;

namespace MoneyAdmin.Domain.Models
{
    public class Category : Entity
    {
        public string Name { get; private set; }

        protected Category() { }

        public Category(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}
