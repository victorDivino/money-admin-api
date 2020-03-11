using Microsoft.EntityFrameworkCore;
using MoneyAdmin.Domain;
using MoneyAdmin.Domain.Models;
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
            modelBuilder.ApplyConfiguration(new CategoryMap());
            base.OnModelCreating(modelBuilder);
            
        }

        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<ExpensePayment> ExpensePayments { get; set; }
        public DbSet<IncomePayment> IncomePayments { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Income> Incomes { get; set; }
    }
}
