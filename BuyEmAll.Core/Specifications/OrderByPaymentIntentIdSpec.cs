using BuyEmAll.Core.Entities.OrderAggregate;

namespace BuyEmAll.Core.Specifications
{
    public class OrderByPaymentIntentIdSpec : BaseSpecification<Order>
    {
        public OrderByPaymentIntentIdSpec(string email) 
            : base(o => o.Email == email)
        {
            AddInclude(o => o.OrderItems);
            AddInclude(o => o.DeliveryMethod);
            AddOrderByDescending(o => o.OrderDate);
        }

        public OrderByPaymentIntentIdSpec(int id, string email) : base(o => o.Id == id && o.Email == email)
        {
            AddInclude(o => o.OrderItems);
            AddInclude(o => o.DeliveryMethod);
        }
    }
}
