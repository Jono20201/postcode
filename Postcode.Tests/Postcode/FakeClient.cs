using System;
using System.Threading.Tasks;
using Postcode.Contracts;
using Postcode.Models;

namespace Postcode.Tests.Postcode
{
    public class FakeClient : IPostcodeClient
    {
        public Task<PostcodeLookupResponse> LookupAsync(PostcodeLookupRequest request)
        {
            throw new NotImplementedException();
        }
    }
}