using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.Protected;
using ProjektWWW.NET_FR_LB.Data;
using ProjektWWW.NET_FR_LB.Models;
using Xunit;
using System.Linq;

public class CurrencyApiServiceTests
{
    [Fact]
    public async Task GetAvailableCurrenciesAsync_ReturnsCorrectDictionary()
    {
        // Arrange
        var data = new List<Waluta>
        {
            new Waluta { Kod = "USD", Nazwa = "Dolar", Kraj = "USA" },
            new Waluta { Kod = "EUR", Nazwa = "Euro", Kraj = "Unia Europejska" }
        }.AsQueryable();

        var mockSet = new Mock<DbSet<Waluta>>();
        mockSet.As<IQueryable<Waluta>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<Waluta>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<Waluta>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<Waluta>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

        var mockContext = new Mock<Kantor1DbContext>();
        mockContext.Setup(c => c.Waluty).Returns(mockSet.Object);

        var service = new CurrencyApiService(new HttpClient(), mockContext.Object);

        // Act
        var result = await service.GetAvailableCurrenciesAsync();

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Equal("USA Dolar", result["USD"]);
        Assert.Equal("Unia Europejska Euro", result["EUR"]);
    }

    [Fact]
    public async Task GetExchangeRateAsync_ValidJson_ReturnsRate()
    {
        // Arrange
        var responseJson = @"{
            ""rates"": {
                ""USD"": 1.0,
                ""PLN"": 4.5
            }
        }";

        var handlerMock = new Mock<HttpMessageHandler>();
        handlerMock
           .Protected()
           .Setup<Task<HttpResponseMessage>>(
              "SendAsync",
              ItExpr.IsAny<HttpRequestMessage>(),
              ItExpr.IsAny<CancellationToken>()
           )
           .ReturnsAsync(new HttpResponseMessage
           {
               StatusCode = HttpStatusCode.OK,
               Content = new StringContent(responseJson),
           });

        var httpClient = new HttpClient(handlerMock.Object);

        var mockContext = new Mock<Kantor1DbContext>();
        var service = new CurrencyApiService(httpClient, mockContext.Object);

        // Act
        var result = await service.GetExchangeRateAsync("USD", "PLN");

        // Assert
        Assert.NotNull(result);
        Assert.Equal(4.5, result.Value);
    }
}
