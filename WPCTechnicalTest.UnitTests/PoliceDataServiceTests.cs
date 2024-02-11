using Moq.Protected;
using WPCTechnicalTest.Dto;
using WPCTechnicalTest.Services;

namespace WPCTechnicalTest.UnitTests;

public class PoliceDataServiceTests
{
    private readonly Mock<IHttpClientFactory> _mockHttpClientFactory;
    private readonly Mock<HttpMessageHandler> _mockHandler;

    private readonly IPoliceDataService _policeDataService;

    public PoliceDataServiceTests()
    {
        _mockHandler = new Mock<HttpMessageHandler>();

        var httpClient = new HttpClient(_mockHandler.Object)
        {
            BaseAddress = new Uri("https://data.police.uk")
        };

        _mockHttpClientFactory = new Mock<IHttpClientFactory>();
        _mockHttpClientFactory
            .Setup(x => x.CreateClient("PoliceData"))
            .Returns(httpClient);

        _policeDataService = new PoliceDataService(_mockHttpClientFactory.Object);
    }

    #region GetLastCrimeUpdatedDate

    [Fact]
    public async Task GetLastCrimeUpdatedDate_ApiReturnsBadRequest_NullReturned()
    {
        // Arrange
        const string responseContent = "{\"date\":\"2023-12-01\"}";

        var response = new HttpResponseMessage
        {
            StatusCode = System.Net.HttpStatusCode.BadRequest,
            Content = null
        };
        BuildHandlerMock(response);

        // Act
        var result = await _policeDataService.GetLastCrimeUpdatedDate(CancellationToken.None);

        // Assert
        result.Should().BeNull();
    }

    [Fact]
    public async Task GetLastCrimeUpdatedDate_ApiReturnsIncorrectFormatData_NullReturned()
    {
        // Arrange
        const string responseContent = "{\"Nodate\":\"2023-12-01\"}";

        var response = new HttpResponseMessage
        {
            StatusCode = System.Net.HttpStatusCode.OK,
            Content = new StringContent(responseContent)
        };
        BuildHandlerMock(response);

        // Act
        var result = await _policeDataService.GetLastCrimeUpdatedDate(CancellationToken.None);

        // Assert
        result.Should().BeNull();
    }

    [Fact]
    public async Task GetLastCrimeUpdatedDate_ApiReturnsValidData_LastCrimeDateDtoReturned()
    {
        // Arrange
        const string responseContent = "{\"date\":\"2023-12-01\"}";
        var expectedResponseDate = new DateTime(2023, 12, 01);

        var response = new HttpResponseMessage
        {
            StatusCode = System.Net.HttpStatusCode.OK,
            Content = new StringContent(responseContent)
        };
        BuildHandlerMock(response);

        // Act
        var result = await _policeDataService.GetLastCrimeUpdatedDate(CancellationToken.None);

        // Assert
        result.Should().NotBeNull().And.BeOfType<LastCrimeDateDto>();
        result.LastCrimeDate.Should().Be(expectedResponseDate);
    }

    #endregion

    #region GetCrimeDataByLocationAndDate

    [Fact]
    public async Task GetCrimeDataByLocationAndDate_ApiReturnsBadRequest_NullReturned()
    {
        // Arrange
        var response = new HttpResponseMessage
        {
            StatusCode = System.Net.HttpStatusCode.BadRequest,
            Content = null
        };
        BuildHandlerMock(response);

        var searchCriteria = new SearchCriteriaDto
        {
            Latitude = "51.44237",
            Longitude = "-2.49810",
            Date = "2021-01"
        };

        // Act
        var result = await _policeDataService.GetCrimeDataByLocationAndDate(searchCriteria, CancellationToken.None);

        // Assert
        result.Should().BeNull();
    }

    [Fact]
    public async Task GetCrimeDataByLocationAndDate_ApiReturnsNoResults_EmptyListReturned()
    {
        // Arrange
        var responseContent = "[]";

        var response = new HttpResponseMessage
        {
            StatusCode = System.Net.HttpStatusCode.OK,
            Content = new StringContent(responseContent)
        };
        BuildHandlerMock(response);

        var searchCriteria = new SearchCriteriaDto
        {
            Latitude = "51.44237",
            Longitude = "-2.49810",
            Date = "2021-01"
        };

        // Act
        var result = await _policeDataService.GetCrimeDataByLocationAndDate(searchCriteria, CancellationToken.None);

        // Assert
        result.Should().BeOfType<List<CrimeDto>>();
        result.Should().BeEmpty();
    }

    [Fact]
    public async Task GetCrimeDataByLocationAndDate_ApiReturnsValidData_ListOfCrimeDtos()
    {
        // Arrange
        var responseContent = GetValidCrimeData();

        var response = new HttpResponseMessage
        {
            StatusCode = System.Net.HttpStatusCode.OK,
            Content = new StringContent(responseContent)
        };
        BuildHandlerMock(response);

        var searchCriteria = new SearchCriteriaDto
        {
            Latitude = "51.44237",
            Longitude = "-2.49810",
            Date = "2021-01"
        };

        // Act
        var result = await _policeDataService.GetCrimeDataByLocationAndDate(searchCriteria, CancellationToken.None);

        // Assert
        result.Should().BeOfType<List<CrimeDto>>();
        result.Should().NotBeEmpty().And.HaveCount(2);
    }

    #endregion

    #region Helpers

    private void BuildHandlerMock(HttpResponseMessage response)
    {
        _mockHandler
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(response);
    }

    private static string GetValidCrimeData()
    {
        var data = "[\r\n    {\r\n        \"category\": \"anti-social-behaviour\",\r\n        \"context\": \"\",\r\n        \"id\": 89509657,\r\n        \"location\": {\r\n            \"latitude\": \"51.449021\",\r\n            \"longitude\": \"-2.500426\",\r\n            \"street\": {\r\n                \"id\": 542387,\r\n                \"name\": \"On or near Parking Area\"\r\n            }\r\n        },\r\n        \"location_subtype\": \"\",\r\n        \"location_type\": \"Force\",\r\n        \"month\": \"2021-01\",\r\n        \"outcome_status\": null,\r\n        \"persistent_id\": \"\"\r\n    },\r\n    {\r\n        \"category\": \"anti-social-behaviour\",\r\n        \"context\": \"\",\r\n        \"id\": 89509899,\r\n        \"location\": {\r\n            \"latitude\": \"51.447177\",\r\n            \"longitude\": \"-2.500535\",\r\n            \"street\": {\r\n                \"id\": 542391,\r\n                \"name\": \"On or near Kingsfield Lane\"\r\n            }\r\n        },\r\n        \"location_subtype\": \"\",\r\n        \"location_type\": \"Force\",\r\n        \"month\": \"2021-01\",\r\n        \"outcome_status\": null,\r\n        \"persistent_id\": \"\"\r\n    }]";

        return data;
    }

    #endregion
}