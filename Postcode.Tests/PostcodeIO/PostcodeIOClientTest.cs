using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using FluentAssertions.Execution;
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
            _server = WireMockServer.Start("api.postcodes.io");
        }

        [Test]
        public async Task GivenValidRequest_WhenLookupAsyncCalled_ThenApiCalled()
        {
            const string postcode = "SW1W 9SJ";
            var responseText = await File.ReadAllTextAsync("PostcodeIO/mocks/success.json");
            _server.Given(Request.Create().WithPath($"/postcode/{postcode}").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBody(responseText));

            var sut = CreateClient();

            var response = await sut.LookupAsync(new PostcodeLookupRequest {Postcode = postcode});

            using (new AssertionScope())
            {
                response.StatusCode.Should().Be(HttpStatusCode.OK);
                var result = response.Results.First();

                result.Postcode.Should().Be("SW1W 9SJ");
            }
        }

        private PostcodesIoClient CreateClient() => new PostcodesIoClient(new PostcodeIoOptions
        {
            BaseUrl = _server.Urls.First()
        });

        [TearDown]
        public void TearDown()
        {
            _server.Stop();
        }
    }
}