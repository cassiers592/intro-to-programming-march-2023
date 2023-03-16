
using LearningResourcesApi.Domain;

namespace LearningResourcesApi.Controllers;

public class LearningResourcesController : ControllerBase
{
    private readonly LearningResourcesDataContext _context;

    public LearningResourcesController(LearningResourcesDataContext context)
    {
        _context = context;
    }

    [HttpPost("/learning-resources")]
    public async Task<ActionResult<LearningResourceSummaryItem>> AddResources([FromBody] LearningResourcesCreateRequest request)
    {
        // Validate it... if it doesn't meet the invariants, return a 400
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

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
        return Ok(response);
    }

    [HttpGet("/learning-resources")]
    public async Task<ActionResult<LearningResourcesResponse>> GetLearningResources()
    {
        var data = await _context.LearningResources
            .Where(item => item.WhenRemoved == null)
            .Select(item => new LearningResourceSummaryItem(
                item.ID.ToString(), item.Name, item.Description, item.Link))
            .ToListAsync();

        var response = new LearningResourcesResponse(data);
        return Ok(response);
    }
}
