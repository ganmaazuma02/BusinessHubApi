using BusinessHubApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessHubApi.Services
{
    public interface IBusinessService
    {

        Task<Business> GetBusinessAsync(Guid id);
        Task<IEnumerable<Business>> GetBusinessesAsync();
    }
}
