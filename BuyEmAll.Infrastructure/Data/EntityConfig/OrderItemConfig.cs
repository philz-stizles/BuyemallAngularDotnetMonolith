using BuyEmAll.Core.Entities.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuyEmAll.Infrastructure.Data.EntityConfig
{
    public class OrderItemConfig : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.OwnsOne(oi => oi.ItemOrdered, io => { io.WithOwner(); });
            builder.Property(oi => oi.Price)
                .HasColumnType("decimal(18, 2)");
        }
    }
}
