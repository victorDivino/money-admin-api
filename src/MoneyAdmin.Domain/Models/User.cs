using System;
using MoneyAdmin.Domain.Core.Models;

namespace MoneyAdmin.Domain.Models
{
    public class User : Entity
    {
        public User(string userName, string password)
        {
            Id = Guid.NewGuid();
            UserName = userName;
            Password = password;
            Role = "user";
        }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
