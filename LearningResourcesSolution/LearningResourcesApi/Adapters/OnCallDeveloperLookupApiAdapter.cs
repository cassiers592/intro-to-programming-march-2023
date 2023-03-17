namespace LearningResourcesApi.Adapters;

// Create one of these classes (adapters) for EACh of the external APIs you will call.
// Each 'server' (or service) you call into
public class OnCallDeveloperLookupApiAdapter
{
    private readonly HttpClient _httpClient;

    public OnCallDeveloperLookupApiAdapter(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<OnCallApiModel> GetOnCallDeveloperAsync()
    {
        var responseMessage = await _httpClient.GetAsync("/oncalldeveloper");
        responseMessage.EnsureSuccessStatusCode(); // make sure you get status code 200-299 if not blow up

        var message = await responseMessage.Content.ReadFromJsonAsync<OnCallApiModel>();

        if(message != null)
        {
            return message;
        }
        else
        {
            throw new Exception("Didn't get any data - handle better in real code");
        }
    }
}
