using JsonProcessorBackendApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.Text.Json;
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
            var myObj = new object() { };

            var req = JsonSerializer.SerializeToElement(myObj);

            //Act
            var res = await _JsonController.PostJsonRequest(req);

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(res.Result);

        }

        [Test]
        public async Task PostJsonRequest_WithInvalidRequest_ReturnsBadRequestResponse()
        {
            //Arrange
           

            var req = new JsonElement() {
            };

            //Act
            var res = await _JsonController.PostJsonRequest(req);

            //Assert
            Assert.IsInstanceOf<BadRequestObjectResult>(res.Result);

        }
    }
}