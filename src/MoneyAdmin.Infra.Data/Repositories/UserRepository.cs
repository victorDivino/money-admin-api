using System.Collections.Generic;
using System.Linq;
using MoneyAdmin.Domain.Models;

namespace MoneyAdmin.Infra.Data.Repositories
{
    public static class UserRepository
    {
        public static User Get(string userName, string password)
        {
            var users = new List<User>
            {
                new User("moneyadmin", "1234")
            };
            return users.Where(u => u.UserName.ToLower() == userName.ToLower() && u.Password == password).FirstOrDefault();
        }
    }
}
