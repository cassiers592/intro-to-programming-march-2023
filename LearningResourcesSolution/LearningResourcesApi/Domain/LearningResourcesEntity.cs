namespace LearningResourcesApi.Domain;

// CSharp object
public class LearningResourcesEntity
{
    public int ID { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty; 
    public string Link { get; set; } = string.Empty;

    public DateTime WhenCreated { get; set; }
    public DateTime? WhenRemoved { get; set; }

    public bool HasBeenWatched { get; set; }
}
