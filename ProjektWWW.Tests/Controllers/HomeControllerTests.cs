using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using ProjektWWW.NET_FR_LB.Controllers;
using ProjektWWW.NET_FR_LB.Data;
using Xunit;

public class HomeControllerTests
{
    [Fact]
    public void Index_ReturnsIActionResult()
    {
        // Arrange
        var mockLogger = new Mock<ILogger<HomeController>>();
        var mockDb = new Mock<Kantor1DbContext>();

        var controller = new HomeController(mockLogger.Object, mockDb.Object);

        // Act
        var result = controller.Index();

        // Assert
        Assert.IsAssignableFrom<IActionResult>(result);
    }
}
