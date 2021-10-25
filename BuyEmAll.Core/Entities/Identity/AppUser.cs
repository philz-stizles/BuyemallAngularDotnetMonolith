using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace BuyEmAll.Core.Entities.Identity
{
    public class AppUser: IdentityUser
    {
        public string DisplayName { get; set; }
        public ICollection<Address> Addresses { get; set; }
    }
}