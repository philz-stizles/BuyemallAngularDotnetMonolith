using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace BuyEmAll.Core.Entities
{
    public class AppUser: IdentityUser
    {
        public string DisplayName { get; set; }
        public ICollection<Address> Addresss { get; set; }
    }
}