
using LearningResourcesApi.Domain;

namespace LearningResourcesApi.Controllers;

public class LearningResourcesController : ControllerBase
{
    private readonly IManageLearningResources _resourceManager;

    public LearningResourcesController(IManageLearningResources resourceManager)
    {
        _resourceManager = resourceManager;
    }

    [HttpDelete("/learning-resources/{resourceId:int}")]
    public async Task<ActionResult> Remove(int resourceId)
    {
        // Idempotent - doing it multiple times is the same as doing it once.
        // check to see if there is a resource with id, and if there is "remove"
        await _resourceManager.RemoveItemAsync(resourceId);
        return NoContent(); // passive-aggressive "Fine!"
    }

    [HttpPost("/learning-resources")]
    public async Task<ActionResult<LearningResourceSummaryItem>> AddResources([FromBody] LearningResourcesCreateRequest request)
    {
        // Validate it... if it doesn't meet the invariants, return a 400
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        LearningResourceSummaryItem response = await _resourceManager.AddResourceAsync(request);
        return Ok(response);
    }

    [HttpGet("/learning-resources")]
    public async Task<ActionResult<LearningResourcesResponse>> GetLearningResources(CancellationToken token)
    {
        LearningResourcesResponse response = await _resourceManager.GetCurrentResourcesAsync(token);
        return Ok(response);
    }
}
