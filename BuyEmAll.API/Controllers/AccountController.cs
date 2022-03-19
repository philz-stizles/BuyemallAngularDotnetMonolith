using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using BuyEmAll.API.Dtos.Account;
using BuyEmAll.API.Errors;
using BuyEmAll.Core.Entities.Identity;
using BuyEmAll.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BuyEmAll.API.Controllers
{
    public class AccountController : BaseController
    {
        private readonly ILogger<AccountController> _logger;
        private readonly UserManager<AppUser> _userMgr;
        private readonly SignInManager<AppUser> _signInMgr;
        private readonly ITokenService _tokenSrv;

        // private readonly IMapper _mapper;

        public AccountController(ILogger<AccountController> logger, UserManager<AppUser> userMgr,
            SignInManager<AppUser> signInMgr, IMapper mapper, ITokenService tokenSrv): base(mapper)
        {
            _signInMgr = signInMgr;
            _tokenSrv = tokenSrv;
            // _mapper = mapper;
            _userMgr = userMgr;
            _logger = logger;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var newUser = _mapper.Map<AppUser>(dto);
            newUser.UserName = dto.DisplayName.Replace(" ", ""); // UserName must not have any spaces, this IdentityUser behaviour 
            // can be hidden in the child AppUser
            var result = await _userMgr.CreateAsync(newUser);
            if (!result.Succeeded) return BadRequest(new ApiResponse(400));

            return Ok(new
            {
                Status = true,
                Data = new { 
                    LoggedInUser = _mapper.Map<LoggedInUserDto>(newUser),
                    Token = _tokenSrv.CreateToken(newUser)
                },
                Messsage = "Registration Successful"
            });
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var exisitngUser = await _userMgr.FindByEmailAsync(dto.Email);
            if(exisitngUser == null) return Unauthorized(new ApiResponse(401));

            var result = await _signInMgr.CheckPasswordSignInAsync(exisitngUser, dto.Password, false);
            if (!result.Succeeded) return Unauthorized(new ApiResponse(401));

            return Ok(new { 
                Status = true, 
                Data = new { 
                    LoggedInUser = _mapper.Map<LoggedInUserDto>(exisitngUser),
                    token = _tokenSrv.CreateToken(exisitngUser)
                }, 
                Messsage = "Login Successful"
            });
        }

        [Authorize]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetCurrentUser()
        {
            var userEmail = HttpContext.User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;

            var user = await _userMgr.FindByEmailAsync(userEmail);

            return Ok(new
            {
                Status = true,
                Data = new
                {
                    LoggedInUser = _mapper.Map<LoggedInUserDto>(user),
                    token = _tokenSrv.CreateToken(user)
                },
                Messsage = "Login Successful"
            });
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> CheckEmailExists([FromQuery]string email)
        {
            var user = await _userMgr.FindByEmailAsync(email);
            return Ok(new
            {
                Status = true,
                Data = (user == null) ? false : true,
                Messsage = "Login Successful"
            });
        }
    }
}
