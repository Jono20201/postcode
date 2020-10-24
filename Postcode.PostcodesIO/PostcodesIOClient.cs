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

            var httpContent = await httpResponse.Content.ReadAsStringAsync();
            var deserializedResponse =
                JsonConvert.DeserializeObject<ApiLookupResponse>(httpContent);

            var response = new PostcodeLookupResponse
            {
                Successful = false,
                StatusCode = httpResponse.StatusCode,
                Results = new[]
                {
                    MapResult(deserializedResponse.Result)
                }
            };

            return response;
        }

        private static PostcodeLookup MapResult(ApiLookupResponseResult result)
        {
            return new PostcodeLookup
            {
                Postcode = result.Postcode,
                Latitude = result.Latitude,
                Longitude = result.Longitude,
                Eastings = result.Eastings,
                Northings = result.Northings,
                City = result.Parish,
                County = result.AdminCounty
            };
        }
    }
}