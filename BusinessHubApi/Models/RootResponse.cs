using BusinessHubApi.Models;

namespace BusinessHubApi.Models
{

    internal class RootResponse : Resource
    {
        public Link Info { get; set; }
        public Link Businesses { get; set; }
    }
}