using BusinessHubApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessHubApi
{
    public class BusinessHubApiDbContext : DbContext
    {
        public BusinessHubApiDbContext(DbContextOptions options) : base(options) {}

        public DbSet<BusinessEntity> Businesses { get; set; }
    }
}
