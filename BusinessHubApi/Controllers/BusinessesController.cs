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
        public async Task<ActionResult<Collection<Business>>> GetAllBusinesses()
        {
            var rooms = await _businessService.GetBusinessesAsync();

            var collection = new Collection<Business>
            {
                Self = Link.ToCollection(nameof(GetAllBusinesses)),
                Value = rooms.ToArray()
            };

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
