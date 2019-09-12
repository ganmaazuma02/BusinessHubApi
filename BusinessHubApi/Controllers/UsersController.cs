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
    public class UsersController : ControllerBase
    {
        private readonly PagingOptions _defaultPagingOptions;
        private readonly IUserService _userService;

        public UsersController(
            IUserService userService,
            IOptions<PagingOptions> defaultPagingOptionsWrapper)
        {
            _defaultPagingOptions = defaultPagingOptionsWrapper.Value;
            _userService = userService;
        }

        [HttpGet(Name = nameof(GetVisibleUsers))]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<PagedCollection<User>>> GetVisibleUsers(
            [FromQuery] PagingOptions pagingOptions = null)
        {
            pagingOptions.Offset = pagingOptions.Offset ?? _defaultPagingOptions.Offset;
            pagingOptions.Limit = pagingOptions.Limit ?? _defaultPagingOptions.Limit;

            // TODO: Auth

            var users = await _userService.GetUsersAsync(pagingOptions);

            var collection = PagedCollection<User>.Create(
                Link.ToCollection(nameof(GetVisibleUsers)),
                users.Items.ToArray(),
                users.TotalSize,
                pagingOptions);

            return collection;
        }

        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [HttpGet("{userId}", Name = nameof(GetUserById))]
        public async Task<ActionResult<User>> GetUserById(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
