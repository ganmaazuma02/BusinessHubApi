using BusinessHubApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BusinessHubApi.Services
{
    public interface IUserService
    {
        Task<PagedResults<User>> GetUsersAsync(
            PagingOptions pagingOptions);

    }
}
