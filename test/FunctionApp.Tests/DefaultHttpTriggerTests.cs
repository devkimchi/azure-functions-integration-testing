using System.Net.Http;
using System.Threading.Tasks;

using FluentAssertions;

using Microsoft.OpenApi.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Newtonsoft.Json;

namespace FunctionApp.Tests
{
    [TestClass]
    public class DefaultHttpTriggerTests
    {
        private HttpClient _http;

        [TestInitialize]
        public void Initialize()
        {
            this._http = new HttpClient();
        }

        [TestCleanup]
        public void Cleanup()
        {
            this._http.Dispose();
        }

        [TestMethod]
        public async Task Given_OpenApiUrl_When_Endpoint_Invoked_Then_It_Should_Return_Title()
        {
            var response = await this._http.GetStringAsync("http://localhost:7071/api/openapi/v3.json").ConfigureAwait(false);
            var doc = JsonConvert.DeserializeObject<OpenApiDocument>(response);

            doc.Should().NotBeNull();
            doc.Info.Title.Should().Be("OpenAPI Document on Azure Functions");
            doc.Components.Schemas.Should().ContainKey("greeting");

            var schema = doc.Components.Schemas["greeting"];
            schema.Type.Should().Be("object");
            schema.Properties.Should().ContainKey("message");

            var property = schema.Properties["message"];
            property.Type.Should().Be("string");
        }
    }
}
