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
            => options.UseSqlite(@"Data Source='C:\Databases\moneyadmin.db'");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<BankAccount> Accounts { get; set; }
    }
}
