using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyAdmin.Domain;

namespace MoneyAdmin.Infra.Data.Mappings
{
    public sealed class BankAccountMap : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder.ToTable("BankAccount");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasColumnType("varchar(60)")
                .HasMaxLength(60)
                .IsRequired();

            builder.HasMany(x => x.Debts);
            builder.HasMany(x => x.Credits);
        }
    }
}
