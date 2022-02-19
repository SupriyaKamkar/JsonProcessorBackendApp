using JsonProcessorBackendApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace JsonProcessorBackendApp.Tests
{
    [TestFixture]
    public class JsonRequestReaderControllerTest
    {
        private JsonRequestReaderController _JsonController;
        [SetUp]
        public void Setup()
        {
            ILogger<JsonRequestReaderController> logger = Mock.Of<ILogger<JsonRequestReaderController>>();
            _JsonController = new JsonRequestReaderController(logger);
        }

        [Test]
        public async Task PostJsonRequest_WithValidRequest_ReturnsOkResponse()
        {
            //Arrange
            var keyValue = new System.Collections.Generic.KeyValuePair<string, JsonNode?>(
                "name", null);
          

            var req = new JsonObject() {
              keyValue
            };


            //Act
            var res = await _JsonController.PostJsonRequest(req);

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(res.Result);

        }

        [Test]
        public async Task PostJsonRequest_WithInvalidRequest_ReturnsBadRequestResponse()
        {
            //Arrange
           

            var req = new JsonObject() {
            };

            //Act
            var res = await _JsonController.PostJsonRequest(req);

            //Assert
            Assert.IsInstanceOf<BadRequestObjectResult>(res.Result);

        }
    }
}