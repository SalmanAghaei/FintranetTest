using Core.Domain.Products.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Sql.Products.Configurations
{
    internal class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.SKU)
                .IsRequired()
                .HasMaxLength(20);
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(256);
            builder.Property(x => x.ShortDescription)
             .IsRequired()
             .HasMaxLength(1000);
            builder.HasIndex(x => x.SKU).IsUnique();
        }
    }
}
