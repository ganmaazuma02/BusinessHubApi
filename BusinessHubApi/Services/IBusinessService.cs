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
        Task<PagedResults<Business>> GetBusinessesAsync(
            PagingOptions pagingOptions, 
            SortOptions<Business, BusinessEntity> sortOptions,
            SearchOptions<Business, BusinessEntity> searchOptions);
    }
}
