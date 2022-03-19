
using BuyEmAll.Core.Entities;
using BuyEmAll.Core.Entities.OrderAggregate;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace BuyEmAll.Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.Products.Any())
                {
                    var categorySeedLocation = "../BuyEmAll.Infrastructure/Data/SeedData/categories.json";  // Path should be the location
                    // of the DeesData folder relative to the Program.cs where it will be executed
                    if (System.IO.File.Exists(categorySeedLocation))
                    {
                        var serializedCategories = System.IO.File.ReadAllText(categorySeedLocation);
                        var categoryList = JsonSerializer.Deserialize<IReadOnlyList<Category>>(serializedCategories);

                        await context.Categories.AddRangeAsync(categoryList);
                        // await context.SaveChangesAsync();
                    }

                    var brandSeedLocation = "../BuyEmAll.Infrastructure/Data/SeedData/brands.json";  // Path should be the location
                    // of the DeesData folder relative to the Program.cs where it will be executed
                    if (System.IO.File.Exists(brandSeedLocation))
                    {
                        var serializedBrands = System.IO.File.ReadAllText(brandSeedLocation);
                        var brandList = JsonSerializer.Deserialize<IReadOnlyList<Brand>>(serializedBrands);

                        await context.Brands.AddRangeAsync(brandList);
                        // await context.SaveChangesAsync();
                    }

                    var seedLocation = "../BuyEmAll.Infrastructure/Data/SeedData/products.json";  // Path should be the location
                    // of the DeesData folder relative to the Program.cs where it will be executed
                    if (System.IO.File.Exists(seedLocation))
                    {
                        var serializedProducts = System.IO.File.ReadAllText(seedLocation);
                        var productList = JsonSerializer.Deserialize<IReadOnlyList<Product>>(serializedProducts);

                        await context.Products.AddRangeAsync(productList);
                        // await context.SaveChangesAsync();
                    }
                    await context.SaveChangesAsync();
                }

                if (!context.DeliveryMethods.Any())
                {
                    var deliveryMethodsSeedLocation = "../BuyEmAll.Infrastructure/Data/SeedData/delivery.json";  // Path should be the location
                    var serializedProducts = System.IO.File.ReadAllText(deliveryMethodsSeedLocation);
                    var deliveryMethods = JsonSerializer.Deserialize<IReadOnlyList<DeliveryMethod>>(serializedProducts);

                    await context.DeliveryMethods.AddRangeAsync(deliveryMethods);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex, "An error occured while seeding");
            }
        }
    }
}
