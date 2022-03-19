using BuyEmAll.Core.Entities;
using BuyEmAll.Core.Entities.OrderAggregate;
using BuyEmAll.Core.Interfaces.Repositories;
using BuyEmAll.Core.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Stripe;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyEmAll.Infrastructure.Services
{
  public class PaymentService : IPaymentService
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _config;
        
        public PaymentService(IBasketRepository basketRepository, IUnitOfWork unitOfWork,
            IConfiguration config
        )
        {
            _basketRepository = basketRepository;
            _unitOfWork = unitOfWork;
            _config = config;
        }

        public async Task<Basket> CreateOrUpdatePaymentIntent(string basketId)
        {
            StripeConfiguration.ApiKey = _config["StripeSettings:SecretKey"];

            // Get basket from repo.
            var basket = await _basketRepository.GetBasketAsync(basketId);
            var shippingPrice = 0m;

            if(basket.DeliveryMethodId.HasValue) 
            { 
                // Get delivery method.
                var deliverMethod = await _unitOfWork.Repository<DeliveryMethod>().GetByIdAsync((int)basket.DeliveryMethodId);
            }

            foreach (var item in basket.Items)
            { 
                var productItem = await _unitOfWork.Repository<Core.Entities.Product>().GetByIdAsync(item.Id);
                if(productItem.Price != item.Price) 
                {
                    item.Price = productItem.Price;
                }
            }

            var service = new PaymentIntentService();

            PaymentIntent intent;

            if(string.IsNullOrEmpty(basket.PaymentIntentId)) 
            {
                var options = new PaymentIntentCreateOptions
                    {
                    Amount = (long) basket.Items.Sum(i => i.Quantity * (i.Price * 100)) + (long) shippingPrice * 100,
                    Currency = "usd",
                    PaymentMethodTypes = new List<string>{"card"}
                };

                intent = await service.CreateAsync(options);
                basket.PaymentIntentId = intent.Id;
                basket.ClientSecret = intent.ClientSecret;

            } 
            else
            {
                var options = new PaymentIntentUpdateOptions
                    {
                    Amount = (long) basket.Items.Sum(i => i.Quantity * (i.Price * 100)) + (long) shippingPrice * 100,
                };

                await service.UpdateAsync(basket.PaymentIntentId , options);
            }

            await _basketRepository.UpdateBasketAsync(basket);

            return basket;
        }

    public Task<Core.Entities.OrderAggregate.Order> UpdateOrderPaymentFailed(string paymentIntentId)
    {
      throw new System.NotImplementedException();
    }

    public Task<Core.Entities.OrderAggregate.Order> UpdateOrderPaymentSucceeded(string paymentIntentId)
    {
      throw new System.NotImplementedException();
    }
  }
}
