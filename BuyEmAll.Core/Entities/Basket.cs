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
        public List<BasketItem> CartItems { get; set; } = new List<BasketItem>();
    }
}