namespace LearningResourcesApi.Domain;

public class ApiOnCallDeveloperLookup : ILookupOnCallDevelopers
{
    private readonly OnCallDeveloperLookupApiAdapter _adapter;

    public ApiOnCallDeveloperLookup(OnCallDeveloperLookupApiAdapter adapter)
    {
        _adapter = adapter;
    }

    public async Task<StatusHelpInfo> GetCurrentOnCallDeveloperAsync()
    {
        var developerInfo = await _adapter.GetOnCallDeveloperAsync();
        var contactInfo = new Dictionary<string, string> { { "phone", developerInfo.Phone }, { "email", developerInfo.Email } };
        return new StatusHelpInfo(developerInfo.Name, contactInfo);
    }
}
