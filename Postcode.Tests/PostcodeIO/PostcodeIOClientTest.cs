using System.IO;
using System.Threading.Tasks;
using NUnit.Framework;
using Postcode.Models;
using Postcode.PostcodesIO;
using Postcode.PostcodesIO.Options;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

namespace Postcode.Tests.PostcodeIO
{
    [TestFixture]
    public class PostcodeIoClientTest
    {
        private WireMockServer _server;

        [SetUp]
        public void Setup()
        {
            _server = WireMockServer.Start(8080);
        }

        [Test]
        public async Task GivenValidRequest_WhenLookupAsyncCalled_ThenApiCalled()
        {
            const string postcode = "SW1W 9SJ";
            var responseText = await File.ReadAllTextAsync("success.json");
            _server.Given(Request.Create().WithPath($"postcodes/{postcode}").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBody(responseText));

            var sut = CreateClient();

            var response = await sut.LookupAsync(new PostcodeLookupRequest {Postcode = postcode});
            
        }

        private static PostcodesIoClient CreateClient() => new PostcodesIoClient(new PostcodeIoOptions
        {
            BaseUrl = "http://localhost:8080"
        });

        [TearDown]
        public void TearDown()
        {
            _server.Stop();
        }
    }
}