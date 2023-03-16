namespace LearningResourcesApi.Domain;

public class EntityFrameworkResourceManager : IManageLearningResources
{
    private readonly LearningResourcesDataContext _context; public EntityFrameworkResourceManager(LearningResourcesDataContext context)
    {
        _context = context;
    }

    public async Task<LearningResourceSummaryItem> AddResourceAsync(LearningResourcesCreateRequest request)
    {
        // Add it to the DB:
        // turn the request into Doman.LearningResourcesEntity
        var entity = new LearningResourcesEntity
        {
            // "Mapping" - AutoMapper can do this automatically
            Name = request.Name,
            Description = request.Description,
            Link = request.Link,
            WhenCreated = DateTime.Now
        };
        // tell our DataContext about it
        _context.LearningResources.Add(entity);
        // tell DataContext to save the data
        await _context.SaveChangesAsync();

        // Return a sucess status code
        // with a copy of the new entity
        var response = new LearningResourceSummaryItem(entity.ID.ToString(), entity.Name, entity.Description, entity.Link);
        return response;
    }

    public async Task<LearningResourcesResponse> GetCurrentResourcesAsync(CancellationToken token)
    {
        var data = await _context.GetActiveLearningResources()
            .Select(item => new LearningResourceSummaryItem(
                item.ID.ToString(), item.Name, item.Description, item.Link))
            .ToListAsync(token);

        var response = new LearningResourcesResponse(data);
        return response;
    }

    public async Task RemoveItemAsync(int resourceId)
    {
        var item = await _context.GetActiveLearningResources().SingleOrDefaultAsync(item => item.ID == resourceId);
        if(item != null)
        {
            item.WhenRemoved = DateTime.Now;
            await _context.SaveChangesAsync();
        }
    }
}
