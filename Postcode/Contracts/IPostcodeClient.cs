using System.Threading.Tasks;
using Postcode.Models;

namespace Postcode.Contracts
{
    public interface IPostcodeClient
    {
        Task<PostcodeLookupResponse> LookupAsync(PostcodeLookupRequest request);
    }
}