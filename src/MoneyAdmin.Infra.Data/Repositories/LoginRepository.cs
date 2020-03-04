using System.Collections.Generic;
using System.Linq;
using MoneyAdmin.Domain.Models;

namespace MoneyAdmin.Infra.Data.Repositories
{
    public static class LoginRepository
    {
        public static Login Get(string userName, string password)
        {
            var users = new List<Login>
            {
                new Login { Id = 1, UserName = "moneyadmin", PassWord = "1234", Role = "user" }
            };
            return users.Where(u => u.UserName.ToLower() == userName.ToLower() && u.PassWord == password).FirstOrDefault();
        }
    }
}
