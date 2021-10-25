using BuyEmAll.Core.Entities.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace BuyEmAll.Infrastructure.Data.EntityConfig
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.OwnsOne(o => o.ShipToAddress, a => {
                a.WithOwner();
                a.Property(a => a.FirstName).IsRequired();
                a.Property(a => a.LastName).IsRequired();
            });
            builder.Property(o => o.OrderStatus)
                .HasConversion(
                    s => s.ToString(), 
                    s => (OrderStatus) Enum.Parse(typeof(OrderStatus), s)
                );
            builder.HasMany(o => o.OrderItems).WithOne().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
