using BuyEmAll.Core.Entities;

namespace BuyEmAll.Core.Interfaces.Services
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
