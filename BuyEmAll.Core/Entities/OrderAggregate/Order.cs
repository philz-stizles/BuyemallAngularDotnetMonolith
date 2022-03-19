using System;
using System.Collections.Generic;

namespace BuyEmAll.Core.Entities.OrderAggregate
{
    public class Order: BaseEntity
    {
        public Order()
        {

        }

        public Order(IReadOnlyList<OrderItem> orderItems, string email, Address shipToAddress, DeliveryMethod deliveryMethod, 
            decimal subtotal, string paymentIntentId
        )
        {
            Email = email;
            ShipToAddress = shipToAddress;
            DeliveryMethod = deliveryMethod;
            OrderItems = orderItems;
            Subtotal = subtotal;
        }

        public string Email { get; set; }
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
        public Address ShipToAddress { get; set; }
        public DeliveryMethod DeliveryMethod { get; set; }
        public IReadOnlyList<OrderItem> OrderItems { get; set; }
        public decimal Subtotal { get; set; }
        public OrderStatus OrderStatus { get; set; } = OrderStatus.Pending;
        public string PaymentIntentId { get; set; }

        public decimal GetTotal () { return Subtotal + DeliveryMethod.Price; }
    }
}