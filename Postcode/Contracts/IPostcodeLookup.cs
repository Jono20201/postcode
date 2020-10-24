using System.Threading.Tasks;
using Postcode.Models;

namespace Postcode.Contracts
{
    public interface IPostcodeLookup
    {
        Task<PostcodeLookupResponse> LookupAsync(PostcodeLookupRequest request);
    }
}