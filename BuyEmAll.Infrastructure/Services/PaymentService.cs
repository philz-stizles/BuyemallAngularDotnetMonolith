using BuyEmAll.Core.Entities;
using BuyEmAll.Core.Interfaces.Services;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace BuyEmAll.Infrastructure.Services
{
    public class PaymentService: IPaymentService
    {
        private readonly ICartRepository _cartRepository;
        private readonly StripeSettings _stripeSettings;

        public PaymentService(ICartRepository cartRepository, IOptions<StripeSettings> stripeOptions)
        {
            _cartRepository = cartRepository;
            _stripeSettings = stripeOptions.Value;
            _stripeSettings = stripeOptions.Value;
        }

        public Task<Basket> CreateOrUpdatePaymentIntent(string basketId)
        {
            throw new System.NotImplementedException();
        }
    }
}
