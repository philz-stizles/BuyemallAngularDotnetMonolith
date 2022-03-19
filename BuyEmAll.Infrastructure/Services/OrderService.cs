using BuyEmAll.Core.Entities;
using BuyEmAll.Core.Entities.OrderAggregate;
using BuyEmAll.Core.Interfaces.Repositories;
using BuyEmAll.Core.Interfaces.Services;
using BuyEmAll.Core.Specifications;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyEmAll.Infrastructure.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBasketRepository _basketRepository;

        public OrderService(IUnitOfWork unitOfWork, IBasketRepository basketRepository)
        {
            _unitOfWork = unitOfWork;
            _basketRepository = basketRepository;
        }

        public async Task<Order> CreateOrderAsync(string ownerEmail, int deliveryMethodId, string basketId, Address shippingAddress)
        {
            // Get basket from repo.
            var basket = await _basketRepository.GetBasketAsync(basketId);

            // Get basket items from product repo.
            var orderItems = new List<OrderItem>();
            foreach (var basketItem in basket.Items)
            {
                var product = await _unitOfWork.Repository<Product>().GetByIdAsync(basketItem.Id);
                var itemOrdered = new ProductItemOrdered(product.Id, product.Name, product.ImageUrl);
                var orderItem = new OrderItem(itemOrdered, product.Price, basketItem.Quantity);
                orderItems.Add(orderItem);
            }

            // Get delivery method.
            var deliverMethod = await _unitOfWork.Repository<DeliveryMethod>().GetByIdAsync(deliveryMethodId);

            // Calculate sub total.
            var subTotal = orderItems.Sum(orderItem => orderItem.Price * orderItem.Quantity);

            // Check if order exists.

            
            // Create order.
            var newOrder = new Order(orderItems, ownerEmail, shippingAddress, deliverMethod, subTotal, null);
            _unitOfWork.Repository<Order>().Add(newOrder);

            // Save to db.
            var result = await _unitOfWork.Complete();

            if(result <= 0) return null;

            // delete basket
            await _basketRepository.DeleteBasketAsync(basketId);

            return newOrder;
    }

        public async Task<Order> GetUserOrderByIdAsync(int orderId, string ownerEmail)
        {
            var spec = new OrdersWithItemsAndOrderingSpec(orderId, ownerEmail);
            return await _unitOfWork.Repository<Order>().GetEntityWithSpecAsync(spec);
        }

        public async Task<IReadOnlyList<Order>> GetUserOrdersAsync(string ownerEmail)
        {
            var spec = new OrdersWithItemsAndOrderingSpec(ownerEmail);
            return await _unitOfWork.Repository<Order>().GetListWithSpecAsync(spec);
        }
    }
}
