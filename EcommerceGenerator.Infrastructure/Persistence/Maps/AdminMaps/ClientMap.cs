using EcommerceGenerator.Domain.Entites.Admin;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcommerceGenerator.Infrastructure.Persistence.Maps.AdminMaps
{
    public class ClientMap : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {

            builder.HasKey(client => client.Id);

            builder.Property(client => client.Name).HasColumnType("varchar(500)").IsRequired();
            builder.Property(client => client.Host).HasColumnType("varchar(500)").IsRequired();
            builder.Property(client => client.DataBase).HasColumnType("varchar(500)").IsRequired();

            builder.Property(client => client.CreatedDate).HasColumnType("smalldatetime").IsRequired();
            builder.Property(client => client.UpdatedDate).HasColumnType("smalldatetime").IsRequired();
            builder.Property(client => client.Active).HasColumnType("bit").IsRequired();

        }
    }
}
