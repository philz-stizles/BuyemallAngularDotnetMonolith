﻿using System;
using System.Collections.Generic;
using BuyEmAll.Core.Entities.OrderAggregate;

namespace BuyEmAll.API.Dtos
{
    public class OrderToReturnDto
    {
        public int Id{ get; set; }
        public string Email { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public Address ShipToAddress { get; set; }
        public string DeliveryMethod { get; set; }
        public decimal ShippingPrice { get; set; }
        public IReadOnlyList<OrderItemDto> OrderItems { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
        public string OrderStatus { get; set; }
        public string PaymentIntentId { get; set; }
    }

    public class OrderItemDto
    {
        public int ProductId{ get; set; }
        public string ProductName { get; set; }
        public string PictureUrl { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
