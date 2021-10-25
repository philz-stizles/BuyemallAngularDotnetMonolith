using BuyEmAll.Core.Entities.Identity;

namespace BuyEmAll.Core.Interfaces.Services
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
