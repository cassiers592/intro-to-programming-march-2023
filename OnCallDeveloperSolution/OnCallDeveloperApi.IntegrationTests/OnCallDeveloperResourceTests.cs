
using Alba;
using OnCallDeveloperApi.Models;

namespace OnCallDeveloperApi.IntegrationTests;

public class OnCallDeveloperResourceTests
{
    [Fact]
    public async Task CanGetOnCallDeveloperDuringBusinessHours()
    {
        // "Host" for our API
        await using var host = await AlbaHost.For<Program>();

        // Scenarios - 
        var response = await host.Scenario(api =>
        {
            api.Get.Url("/oncalldeveloper");
            api.StatusCodeShouldBeOk();
        });

        var expectedResponse = new GetOnCallDeveloperResponse("Mike N.", "555-1212", "mike@aol.com");

        var actualResponse = response.ReadAsJson<GetOnCallDeveloperResponse>();
        
        Assert.NotNull(actualResponse);
        Assert.Equal(expectedResponse, actualResponse);
    }
}
