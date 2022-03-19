using System.Collections.Generic;

namespace BuyEmAll.API.Dtos
{
    public class BasketDto
    {
        public string Id { get; set; } // This will be generated from the client-side
        public List<BasketItemDto> Items { get; set; }
        public int DeliveryMethodId { get; set; }
        // public string ClientSecret { get; set; }
        public string PaymentIntentId { get; set; }
    }
}