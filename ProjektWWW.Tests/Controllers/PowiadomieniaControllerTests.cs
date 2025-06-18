using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using ProjektWWW.NET_FR_LB.Controllers;
using ProjektWWW.NET_FR_LB.Data;
using Microsoft.Extensions.Logging;

namespace ProjektWWW.Tests.Controllers
{
    public class PowiadomieniaControllerTests
    {

        [Fact]
        public void Lista_ReturnsIActionResult()
        {
            // Arrange
            var mockRepo = new Mock<IPowiadomienieRepository>();
            var controller = new PowiadomieniaController(mockRepo.Object);

            // Act
            var result = controller.Lista();

            // Assert
            Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}