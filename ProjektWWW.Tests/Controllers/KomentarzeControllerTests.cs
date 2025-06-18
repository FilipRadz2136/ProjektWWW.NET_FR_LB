using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using ProjektWWW.NET_FR_LB.Controllers;
using ProjektWWW.NET_FR_LB.Data;
using Microsoft.Extensions.Logging;

namespace ProjektWWW.Tests.Controllers
{
    public class KomentarzeControllerTests
    {

        [Fact]
        public void Dodaj_ReturnsIActionResult()
        {
            // Arrange
            var mockContext = new Mock<Kantor1DbContext>();
            var mockPowiadomienieRepo = new Mock<IPowiadomienieRepository>();
            var controller = new KomentarzeController(mockContext.Object, mockPowiadomienieRepo.Object);

            // Act
            var result = controller.Dodaj();

            // Assert
            Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact]
        public void Lista_ReturnsIActionResult()
        {
            // Arrange
            var mockContext = new Mock<Kantor1DbContext>();
            var mockPowiadomienieRepo = new Mock<IPowiadomienieRepository>();
            var controller = new KomentarzeController(mockContext.Object, mockPowiadomienieRepo.Object);

            // Act
            var result = controller.Lista();

            // Assert
            Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact]
        public void Usun_ReturnsIActionResult()
        {
            // Arrange
            var mockContext = new Mock<Kantor1DbContext>();
            var mockPowiadomienieRepo = new Mock<IPowiadomienieRepository>();
            var controller = new KomentarzeController(mockContext.Object, mockPowiadomienieRepo.Object);

            // Act
            var result = controller.Usun();

            // Assert
            Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}