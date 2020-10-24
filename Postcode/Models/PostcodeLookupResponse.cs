using System.Collections.Generic;
using System.Net;

namespace Postcode.Models
{
    public class PostcodeLookupResponse
    {
        public bool Successful { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public IEnumerable<PostcodeLookup> Results { get; set; }
    }
}