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


    }
}
