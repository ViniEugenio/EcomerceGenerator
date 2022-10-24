using EcommerceGenerator.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcommerceGenerator.Infrastructure.Persistence.Maps
{
    public class UserMap : IEntityTypeConfiguration<User>
    {

        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.Property(client => client.CreatedDate).HasColumnType("smalldatetime").IsRequired();
            builder.Property(client => client.UpdatedDate).HasColumnType("smalldatetime").IsRequired();
            builder.Property(client => client.Active).HasColumnType("bit").IsRequired();

        }

    }
}
