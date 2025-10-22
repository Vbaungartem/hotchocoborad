using VB.HotChocoBoard.Domain.Abstraction.Entities;
using VB.HotChocoBoard.Domain.Projects.Entities;
using VB.HotChocoBoard.Domain.Sprints.Entities;
using VB.HotChocoBoard.Domain.Tasks.Entities;
using VB.HotChocoBoard.Domain.UserStories.Enums;

namespace VB.HotChocoBoard.Domain.UserStories.Entities;

public class UserStory : Entity
{
    public UserStory()
    { }
    
    public UserStory(
        int projectId,
        string title,
        string description,
        Priority priority, 
        int? sprintId = null)
    {
        Title = title;
        Description = description;
        ProjectId = projectId;
        Priority = priority;
        SprintId = sprintId;
    }
    
    public int? SprintId { get; private set; }
    
    public int ProjectId { get; private set; }

    public string Title { get; private set; } = string.Empty;
    
    public string Description { get; private set; } = string.Empty;
    
    public Priority Priority { get; private set; }

    public Project Project { get; private set; } = null!;
    
    public Sprint? Sprint { get; private set; }

    public ICollection<TechnicalTask> Tasks { get; private set; } = [];

    public void Update(string title, string description, Priority priority, int? sprintId = null)
    {
        Title = title;
        Description = description;
        Priority = priority;
        SprintId = sprintId;
    }
}