using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyAdmin.Domain.Models;

namespace MoneyAdmin.Infra.Data.Mappings
{
    public sealed class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");
            builder.Property(p => p.Name)
                .HasColumnType("varchar(50)")
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}