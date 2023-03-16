namespace LearningResourcesApi.Domain;

public interface IManageLearningResources
{
    Task<LearningResourceSummaryItem> AddResourceAsync(LearningResourcesCreateRequest request);
    Task<LearningResourcesResponse> GetCurrentResourcesAsync(CancellationToken token);
    Task RemoveItemAsync(int resourceId);
}