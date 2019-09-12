using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BusinessHubApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessHubApi.Services
{
    public class DefaultBusinessService : IBusinessService
    {
        private readonly BusinessHubApiDbContext _context;
        private readonly IConfigurationProvider _mappingConfiguration;

        public DefaultBusinessService(
            BusinessHubApiDbContext context,
            IConfigurationProvider mappingConfiguration)
        {
            _context = context;
            _mappingConfiguration = mappingConfiguration;
        }

        public async Task<Business> GetBusinessAsync(Guid id)
        {
            var entity = await _context.Businesses.SingleOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                return null;
            }

            var mapper = _mappingConfiguration.CreateMapper();
            return mapper.Map<Business>(entity);

        }

        public async Task<PagedResults<Business>> GetBusinessesAsync(
            PagingOptions pagingOptions, 
            SortOptions<Business, BusinessEntity> sortOptions,
            SearchOptions<Business, BusinessEntity> searchOptions)
        {
            IQueryable<BusinessEntity> query = _context.Businesses;
            query = searchOptions.Apply(query);
            query = sortOptions.Apply(query);

            var size = await query.CountAsync();

            var items = await query
                .Skip(pagingOptions.Offset.Value)
                .Take(pagingOptions.Limit.Value)
                .ProjectTo<Business>(_mappingConfiguration)
                .ToArrayAsync();

            return new PagedResults<Business>
            {
                Items = items,
                TotalSize = size
            };
        }
    }
}
