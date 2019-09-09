using BusinessHubApi.Models;
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
            if (context.Businesses.Any())
                return;

            context.Businesses.Add(new BusinessEntity
            {
                //Id = Guid.Parse("ee2b83be-91db-4de5-8122-35a9e9195976"),
                Id = Guid.NewGuid(),
                Name = "Keropok Lekor Mak Lang",
                Description = "Keropok lekor terbaik dari Terengganu!"
            });

            context.Businesses.Add(new BusinessEntity
            {
                Id = Guid.NewGuid(),
                Name = "Nasi Lemak Meleleh",
                Description = "Nasi lemak yang boleh membuat anda meleleh"
            });

            await context.SaveChangesAsync();
        }
    }
}
