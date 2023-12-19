using Microsoft.AspNetCore.Mvc;
using PruebaTecnica;
using PruebaTecnica.Controllers;
using PruebaTecnica.Services;


namespace PruebaTecnicaTest
{
    public class UnitTest1
    {
        private readonly ProveedorController _controller;
        private readonly IProveedorService _service;

        public UnitTest1()
        {
            _service = new ProveedorServiceFake();
            _controller = new ProveedorController(_service);
        }

        [Fact]
        public void Test1()
        {
            // Act
            var okResult = _controller.GetAll();
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public void GetById_UnknownGuidPassed_ReturnsNotFoundResult()
        {
            // Act
            var notFoundResult = _controller.Get(3);
            // Assert
            Assert.IsType<NotFoundObjectResult>(notFoundResult);
        }

        [Fact]
        public void GetById_ExistingGuidPassed_ReturnsOkResult()
        {
            // Arrange
            var testGuid = (987643210);
            // Act
            var okResult = _controller.Get(testGuid);
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }
    }
}