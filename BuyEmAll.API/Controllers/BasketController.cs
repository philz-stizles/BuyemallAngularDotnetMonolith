using System.Threading.Tasks;
using AutoMapper;
using BuyEmAll.API.Errors;
using BuyEmAll.Core.Entities;
using BuyEmAll.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BuyEmAll.API.Controllers
{
    // [Authorize]
    public class BasketController : BaseController
    {
        private readonly ILogger<BasketController> _logger;
        private readonly IBasketRepository _basketRepo;

        public BasketController(ILogger<BasketController> logger, IBasketRepository basketRepo, IMapper mapper) 
            : base(mapper)
        {
            _basketRepo = basketRepo;
            _logger = logger;
        }

        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Basket))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse))]
        public async Task<IActionResult> Create(Basket basket)
        {

            var result = await _basketRepo.UpdateBasketAsync(basket);
            return Ok(result);
        }


        [HttpGet("[action]/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Basket))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse))]
        public async Task<IActionResult> Get(string id)
        {
            var result = await _basketRepo.GetBasketAsync(id);
            return Ok(result ?? new Basket(id));
        }


        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _basketRepo.DeleteBasketAsync(id);
            return Ok(result);
        }
    }
}
