using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using BuyEmAll.API.Dtos;
using BuyEmAll.API.Errors;
using BuyEmAll.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Stripe;

namespace BuyEmAll.API.Controllers
{
  [Authorize]
    public class PaymentsController : BaseController
    {
        private readonly ILogger<PaymentsController> _logger;
        private readonly IPaymentService _paymentService;
        private const string WhSecret = "";
    // private readonly IMapper _mapper;

    public PaymentsController(ILogger<PaymentsController> logger, IPaymentService paymentService, 
            IMapper mapper) : base(mapper)
        {
            _paymentService = paymentService;
            _logger = logger;
        }

        [Authorize]
        [HttpPost("{basketId}")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(BasketDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse))]
        public async Task<ActionResult<BasketDto>> CreateOrder([FromRoute] string basketId)
        {
            var basket = await _paymentService.CreateOrUpdatePaymentIntent(basketId);
            return Ok(_mapper.Map<BasketDto>(basket));
        }

    // Strip will need to access this action and we do not expect Stripe to login, 
    // they need to be able to access this action anonymously.
    [HttpPost("{webhook}")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(BasketDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse))]
    public async Task<ActionResult<BasketDto>> StripeWebook()
    {
      var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();

      var stripeEvent = EventUtility.ConstructEvent(json, Request.Headers["Stripe-Signature"], WhSecret);

      PaymentIntent intent;
      Order order;

      switch (stripeEvent.Type)
      {
        case "payment_intent.succeeded":
          intent = (PaymentIntent)stripeEvent.Data.Object;
          _logger.LogInformation("Payment Succeeded: ", intent.Id);
          break;
        case "payment_intent.failed":
          intent = (PaymentIntent)stripeEvent.Data.Object;
          _logger.LogInformation("Payment Failed: ", intent.Id);
          break;
      }

      return new EmptyResult();
    }
  }
}
