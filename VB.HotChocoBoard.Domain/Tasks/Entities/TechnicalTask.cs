using VB.HotChocoBoard.Domain.Abstraction.Entities;
using VB.HotChocoBoard.Domain.Tasks.Enums;
using VB.HotChocoBoard.Domain.UserStories.Entities;

namespace VB.HotChocoBoard.Domain.Tasks.Entities;

public class TechnicalTask : Entity
{
    public TechnicalTask()
    { }
    
    public TechnicalTask(
        string title, 
        string description,
        int userStoryId,
        int estimatedEffort,
        int completedHours,
        Status status)
    {
        Title = title;
        Description = description;
        UserStoryId = userStoryId;
        EstimatedEffort = estimatedEffort;
        CompletedHours = completedHours;
        Status = status;
    }
    
    public int UserStoryId { get; private set; }

    public string Title { get; private set; } = string.Empty;
    
    public string Description { get; private set; } = string.Empty;
    
    public int EstimatedEffort { get; private set; }
    
    public int CompletedHours { get; private set; }
    
    public Status Status { get; private set; }

    public UserStory UserStory { get; private set; } = null!;

    public void Update(string title, string description, int estimatedEffort, int completedHours, Status status)
    {
        Title = title;
        Description = description;
        EstimatedEffort = estimatedEffort;
        CompletedHours = completedHours;
        Status = status;
    }
}