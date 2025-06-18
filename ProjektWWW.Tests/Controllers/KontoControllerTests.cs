using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using ProjektWWW.NET_FR_LB.Controllers;
using ProjektWWW.NET_FR_LB.Data;
using Microsoft.Extensions.Logging;

namespace ProjektWWW.Tests.Controllers
{
    public class KontoControllerTests
    {

        [Fact]
        public void Login_ReturnsIActionResult_Second()
        {
            // Arrange
            var mockContext = new Mock<Kantor1DbContext>();
            var controller = new KontoController(mockContext.Object);

            // Act
            var result = controller.Login();

            // Assert
            Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact]
        public void Login_ReturnsIActionResult()
        {
            // Arrange
            var mockContext = new Mock<Kantor1DbContext>();
            var controller = new KontoController(mockContext.Object);

            // Act
            var result = controller.Login();

            // Assert
            Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact]
        public void Register_ReturnsIActionResult_Second()
        {
            // Arrange
            var mockContext = new Mock<Kantor1DbContext>();
            var controller = new KontoController(mockContext.Object);

            // Act
            var result = controller.Register();

            // Assert
            Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact]
        public void Register_ReturnsIActionResult()
        {
            // Arrange
            var mockContext = new Mock<Kantor1DbContext>();
            var controller = new KontoController(mockContext.Object);

            // Act
            var result = controller.Register();

            // Assert
            Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact]
        public void Logout_ReturnsIActionResult()
        {
            // Arrange
            var mockContext = new Mock<Kantor1DbContext>();
            var controller = new KontoController(mockContext.Object);

            // Act
            var result = controller.Logout();

            // Assert
            Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}