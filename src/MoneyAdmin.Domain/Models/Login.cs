namespace MoneyAdmin.Domain.Models
{
    public class Login
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string Role { get; set; }
    }
}
