using AutoMapper;
using BuyEmAll.API.Errors;
using Microsoft.AspNetCore.Mvc;

namespace BuyEmAll.API.Controllers
{
    [Route("errors/{code}")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : BaseController
    {
        public ErrorController(IMapper mapper) : base(mapper)
        {
        }

        public IActionResult Error(int code)
        {
            return new ObjectResult(new ApiResponse(code));
        }
    }
}
