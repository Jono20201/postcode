using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Postcode.Contracts;
using Postcode.Models;
using Postcode.PostcodesIO.Model;
using Postcode.PostcodesIO.Options;

namespace Postcode.PostcodesIO
{
    public class PostcodesIoClient : IPostcodeClient
    {
        private HttpClient _httpClient;

        public PostcodesIoClient(PostcodeIoOptions options)
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(options.BaseUrl) };
        }
        
        public async Task<PostcodeLookupResponse> LookupAsync(PostcodeLookupRequest request)
        {
            var httpResponse = await _httpClient.GetAsync($"postcode/{request.Postcode}");

            var deserializedResponse =
                JsonConvert.DeserializeObject<ApiLookupResponse>(await httpResponse.Content.ReadAsStringAsync());

            var response = new PostcodeLookupResponse
            {
                Successful = false,
                StatusCode = httpResponse.StatusCode,
            };

            return response;
        }
    }
}