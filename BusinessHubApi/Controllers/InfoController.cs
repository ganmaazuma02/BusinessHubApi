using BusinessHubApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessHubApi.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        private readonly ApiInfo _apiInfo;

        public InfoController(IOptions<ApiInfo> apiInfoWrapper)
        {
            _apiInfo = apiInfoWrapper.Value;
        }

        [HttpGet(Name = nameof(GetInfo))]
        [ProducesResponseType(200)]
        public ActionResult<ApiInfo> GetInfo()
        {
            _apiInfo.Href = Url.Link(nameof(GetInfo), null);

            return _apiInfo;
        }
    }
}
