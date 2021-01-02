using BuyEmAll.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyEmAll.Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> userMgr, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!userMgr.Users.Any())
                {
                    var admin = new AppUser
                    {
                        DisplayName = "Administrator",
                        Email = "admin@mail.com",
                        UserName = "AdminUser",
                        Addresss = new List<Address>
                        { 
                            new Address{
                                Street = "Buyemall",
                                City = "Yaba",
                                State = "Lagos",
                                Country = "Nigeria",
                                PostalCode = "12345"
                            }
                        }
                    };

                    await userMgr.CreateAsync(admin, "P@ssw0rd");
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<AppIdentityDbContextSeed>();
                logger.LogError(ex, "An error occured while seeding");
            }
        }
    }
}
