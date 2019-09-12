using BusinessHubApi.Models;
using BusinessHubApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessHubApi.Controllers
{
    [Route("/{controller}")]
    [ApiController]
    public class BusinessesController : ControllerBase
    {
        private readonly IBusinessService _businessService;
        private readonly PagingOptions _defaultPagingOptions;

        public BusinessesController(
            IBusinessService businessService,
            IOptions<PagingOptions> defaultPagingOptionsWrapper)
        {
            _businessService = businessService;
            _defaultPagingOptions = defaultPagingOptionsWrapper.Value;
        }

        // GET /businesses
        [HttpGet(Name = nameof(GetAllBusinesses))]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Collection<Business>>> GetAllBusinesses(
            [FromQuery] PagingOptions pagingOptions,
            [FromQuery] SortOptions<Business, BusinessEntity> sortOptions,
            [FromQuery] SearchOptions<Business, BusinessEntity> searchOptions)
        {
            pagingOptions.Offset = pagingOptions.Offset ?? _defaultPagingOptions.Offset;
            pagingOptions.Limit = pagingOptions.Limit ?? _defaultPagingOptions.Limit;

            var businesses = await _businessService.GetBusinessesAsync(pagingOptions, sortOptions, searchOptions);

            var collection = PagedCollection<Business>.Create(
                Link.ToCollection(nameof(GetAllBusinesses)),
                businesses.Items.ToArray(),
                businesses.TotalSize,
                pagingOptions);

            return collection;
        }

        // GET /businesses/{businessId}
        [HttpGet("{businessId}", Name = nameof(GetBusinessById))]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public async Task<ActionResult<Business>> GetBusinessById(Guid businessId)
        {
            var room = await _businessService.GetBusinessAsync(businessId);
            if (room == null) return NotFound();

            return room;
        }
    }
}
