using VB.HotChocoBoard.Domain.Abstraction.Entities;
using VB.HotChocoBoard.Domain.Projects.Entities;
using VB.HotChocoBoard.Domain.UserStories.Entities;

namespace VB.HotChocoBoard.Domain.Sprints.Entities;

public class Sprint : Entity
{
    public Sprint()
    { }

    public Sprint(
        int projectId, 
        string name,
        DateTime startDate,
        DateTime endDate)
    {
        ProjectId = projectId;
        Name = name;
        StartDate = startDate;
        EndDate = endDate;
    }
    
    public int ProjectId { get; private set; }

    public string Name { get; private set; } = string.Empty;
    
    public DateTime StartDate { get; private set; }
    
    public DateTime EndDate { get; private set; }
    
    public Project Project { get; private set; } = null!;

    public ICollection<UserStory> Stories { get; private set; } = [];

    public void Update(string name, DateTime startDate, DateTime endDate)
    {
        Name = name;
        StartDate = startDate;
        EndDate = endDate;
    }
}