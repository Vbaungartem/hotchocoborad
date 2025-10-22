using VB.HotChocoBoard.Domain.Abstraction.Entities;
using VB.HotChocoBoard.Domain.Sprints.Entities;

namespace VB.HotChocoBoard.Domain.Projects.Entities;

public class Project : Entity
{
    public Project()
    { }
    
    public Project(
        string name,
        string description)
    {
        Name = name;
        Description = description;
    }
    
    public string Name { get; private set; } = string.Empty;

    public string Description { get; private set; } = string.Empty;

    public ICollection<Sprint> Sprints { get; private set; } = [];

    public void Update(string name, string description)
    {
        Name = name;
        Description = description;
    }
}