using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using ProjektWWW.NET_FR_LB.Controllers;
using ProjektWWW.NET_FR_LB.Data;
using Microsoft.Extensions.Logging;

namespace ProjektWWW.Tests.Controllers
{
    public class AlertyControllerTests
    {

        [Fact]
        public void Lista_ReturnsIActionResult()
        {
            // Arrange
            var mockDb = new Mock<Kantor1DbContext>();
            var controller = new AlertyController(mockDb.Object);

            // Act
            var result = controller.Lista();

            // Assert
            Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact]
        public void Dodaj_ReturnsIActionResult_SecondInstance()
        {
            // Arrange
            var mockDb = new Mock<Kantor1DbContext>();
            var controller = new AlertyController(mockDb.Object);

            // Act
            var result = controller.Dodaj();

            // Assert
            Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact]
        public void Dodaj_ReturnsIActionResult()
        {
            // Arrange
            var mockDb = new Mock<Kantor1DbContext>();
            var controller = new AlertyController(mockDb.Object);

            // Act
            var result = controller.Dodaj();

            // Assert
            Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}