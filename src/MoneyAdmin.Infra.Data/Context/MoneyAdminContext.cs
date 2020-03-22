using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MoneyAdmin.Domain;
using MoneyAdmin.Domain.Models;
using MoneyAdmin.Infra.Data.Mappings;

namespace MoneyAdmin.Infra.Data
{
    public class MoneyAdminContext : DbContext
    {
        public static string AttachDbPath = @"c:\Databases";

        private readonly IConfiguration _configuration;

        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<ExpensePayment> ExpensePayments { get; set; }
        public DbSet<IncomePayment> IncomePayments { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Income> Incomes { get; set; }

        public MoneyAdminContext(IConfiguration configuration)
            => _configuration = configuration;

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(_configuration.GetConnectionString("MoneyAdminContext"));

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BankAccountMap());
            modelBuilder.ApplyConfiguration(new CategoryMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
