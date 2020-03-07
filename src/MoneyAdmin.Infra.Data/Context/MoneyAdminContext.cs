using Microsoft.EntityFrameworkCore;
using MoneyAdmin.Domain;
using MoneyAdmin.Infra.Data.Mappings;

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
            modelBuilder.ApplyConfiguration(new BankAccountMap());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<BankAccount> BankAccounts { get; set; }
    }
}
