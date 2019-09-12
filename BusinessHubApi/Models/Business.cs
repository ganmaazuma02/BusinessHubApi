using BusinessHubApi.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessHubApi.Models
{
    public class Business : Resource
    {
        [Sortable(Default = true)]
        [SearchableString]
        public string Name { get; set; }

        [Sortable]
        [SearchableString]
        public string Description { get; set; }
    }
}
