using EcommerceGenerator.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcommerceGenerator.Infrastructure.Persistence.Maps
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {

            builder.HasKey(product => product.Id);
            builder.Property(product => product.Name).HasColumnType("varchar(100)").IsRequired();
            builder.Property(product => product.Description).HasColumnType("varchar(MAX)").IsRequired();
            builder.Property(product => product.ImageUrl).HasColumnType("varchar(MAX)").IsRequired();
            builder.Property(product => product.Amount).HasColumnType("int").IsRequired();
            builder.Property(product => product.Price).HasColumnType("decimal").IsRequired();
            builder.Property(product => product.CreatedDate).HasColumnType("smalldatetime").IsRequired();
            builder.Property(product => product.UpdatedDate).HasColumnType("smalldatetime").IsRequired();
            builder.Property(product => product.Active).HasColumnType("bit").IsRequired();

        }
    }
}