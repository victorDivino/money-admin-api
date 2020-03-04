using Microsoft.EntityFrameworkCore;
using MoneyAdmin.Domain;

namespace MoneyAdmin.Infra.Data
{
    public class MoneyAdminContext : DbContext
    {
        public MoneyAdminContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer(@"Server=localhost,1433; Database=Master; User Id=SA; Password=MoneyAdmin@123");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<BankAccount> Accounts { get; set; }
    }
}
