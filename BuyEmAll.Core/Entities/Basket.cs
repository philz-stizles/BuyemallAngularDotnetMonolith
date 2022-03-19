using System.Collections.Generic;

namespace BuyEmAll.Core.Entities
{
    public class Basket: BaseEntity
    {
        public Basket()
        {
        }

        public Basket(string id)
        {
            Id = id;
        }

        public new string Id { get; set; } // This will be generated from the client-side
        public List<BasketItem> Items { get; set; } = new List<BasketItem>();
        public int? DeliveryMethodId { get; set; }
        public string ClientSecret { get; set; }
        public string PaymentIntentId { get; set; }
    }
}