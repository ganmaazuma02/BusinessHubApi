using BusinessHubApi.Models;
using Microsoft.AspNetCore.Identity;
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
            await AddTestUsers(
                services.GetRequiredService<RoleManager<UserRoleEntity>>(),
                services.GetRequiredService<UserManager<UserEntity>>());

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

            context.Businesses.Add(new BusinessEntity
            {
                Id = Guid.NewGuid(),
                Name = "Nasi Ayam",
                Description = "Nasi ayam sedap"
            });

            context.Businesses.Add(new BusinessEntity
            {
                Id = Guid.NewGuid(),
                Name = "Chicken Chop Outstanding",
                Description = "Very outstanding"
            });

            context.Businesses.Add(new BusinessEntity
            {
                Id = Guid.NewGuid(),
                Name = "Wantan Mee",
                Description = "Very delicious"
            });

            context.Businesses.Add(new BusinessEntity
            {
                Id = Guid.NewGuid(),
                Name = "Mee Kari",
                Description = "Mee kari berapi"
            });

            context.Businesses.Add(new BusinessEntity
            {
                Id = Guid.NewGuid(),
                Name = "Hokkien Mee Ah Seng",
                Description = "Sedap teramat"
            });

            context.Businesses.Add(new BusinessEntity
            {
                Id = Guid.NewGuid(),
                Name = "Nasi Kandar Maima",
                Description = "Memang powerrrrr"
            });

            context.Businesses.Add(new BusinessEntity
            {
                Id = Guid.NewGuid(),
                Name = "Mee Kuah",
                Description = "Perghhh"
            });

            context.Businesses.Add(new BusinessEntity
            {
                Id = Guid.NewGuid(),
                Name = "Western Delights",
                Description = "So westernized"
            });

            context.Businesses.Add(new BusinessEntity
            {
                Id = Guid.NewGuid(),
                Name = "Fish n Chips",
                Description = "Fresh fish from the sea"
            });

            context.Businesses.Add(new BusinessEntity
            {
                Id = Guid.NewGuid(),
                Name = "Ikan Bakar",
                Description = "Ikan Bakar superr"
            });

            await context.SaveChangesAsync();
        }

        private static async Task AddTestUsers(
            RoleManager<UserRoleEntity> roleManager,
            UserManager<UserEntity> userManager)
        {
            var dataExists = roleManager.Roles.Any() || userManager.Users.Any();
            if(dataExists)
            {
                return;
            }

            await roleManager.CreateAsync(new UserRoleEntity("admin"));

            var user = new UserEntity
            {
                Email = "admin@businesshub.com",
                UserName = "admin",
                FirstName = "Admin",
                LastName = "Tester",
                CreatedAt = DateTimeOffset.Now
            };

            await userManager.CreateAsync(user, "@Secret123");

            await userManager.AddToRoleAsync(user, "admin");
            await userManager.UpdateAsync(user);
        }
    }
}
