using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BuyEmAll.API.Dtos;
using BuyEmAll.API.Errors;
using BuyEmAll.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BuyEmAll.API.Controllers
{
    [Authorize]
    public class DeliveryMethodsController : BaseController
    {
        private readonly ILogger<DeliveryMethodsController> _logger;
        private readonly IDeliveryMethodService _deliveryMethodService;
        // private readonly IMapper _mapper;

        public DeliveryMethodsController(ILogger<DeliveryMethodsController> logger, 
            IDeliveryMethodService deliveryMethodService, IMapper mapper) : base(mapper)
        {
            _deliveryMethodService = deliveryMethodService;
            _logger = logger;
        }

        // [HttpPost]
        // [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(OrderDto))]
        // [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse))]
        // [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse))]
        // public async Task<IActionResult> CreateOrder([FromBody] OrderDto orderDto)
        // {

        //     var ownerEmail = HttpContext.User.RetrieveEmailFromPrincipal();
        //     var shippingAddress = _mapper.Map<AddressDto, Address>(orderDto.ShipToAddress);
        //     var order = await _orderService.CreateOrderAsync(ownerEmail, orderDto.DeliveryMethodId, orderDto.BasketId, shippingAddress);

        //     if(order == null)
        //     {
        //         return BadRequest(new ApiResponse(400, "Problem creating order"));
        //     }

        //     return Ok(order);
        // }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<DeliveryMethodDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse))]
        public async Task<ActionResult<IReadOnlyList<DeliveryMethodDto>>> GetDeliveryMethods()
        {
            var orders = await _deliveryMethodService.GetDeliveryMethodsAsync();
            return Ok(_mapper.Map<IReadOnlyList<DeliveryMethodDto>>(orders));
        }

        // [HttpGet("{id}")]
        // [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrderDto))]
        // [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse))]
        // public async Task<ActionResult<OrderDto>> GetUserOrder(int id)
        // {
        //     var ownerEmail = HttpContext.User.RetrieveEmailFromPrincipal();
        //     var order = await _orderService.GetUserOrderByIdAsync(id, ownerEmail);

        //     if(order == null) return NotFound(new ApiResponse(404));

        //     return Ok(_mapper.Map<OrderDto>(order));
        // }
    }
}
