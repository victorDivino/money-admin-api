using MoneyAdmin.Domain.Core.Models;

namespace MoneyAdmin.Domain.Models
{
    public class Login : Entity
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string Role { get; set; }
    }
}
