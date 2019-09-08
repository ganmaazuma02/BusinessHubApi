using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessHubApi.Models
{
    public class ApiInfo : Resource
    {
        public string ApiName { get; set; }

        public string AuthorName { get; set; }

        public string AuthorEmail { get; set; }

        public string Description { get; set; }

    }

}
