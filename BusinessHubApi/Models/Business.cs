using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessHubApi.Models
{
    public class Business : Resource
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
