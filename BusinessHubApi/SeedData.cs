using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessHubApi
{
    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider services)
        {
            await AddTestData(
                services.GetRequiredService<BusinessHubApiDbContext>());
        }

        public static async Task AddTestData(
            BusinessHubApiDbContext context)
        {
            

        }
    }
}
