using Microsoft.EntityFrameworkCore;
using VB.HotChocoBoard.Domain.Projects.Entities;
using VB.HotChocoBoard.Domain.Sprints.Entities;
using VB.HotChocoBoard.Domain.Tasks.Entities;
using VB.HotChocoBoard.Domain.UserStories.Entities;

namespace VB.HotChocoBoard.Infrastructure.Data;

public sealed class BoardDbContext(DbContextOptions<BoardDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        
        base.OnModelCreating(modelBuilder);
    }
    
    public DbSet<Project> Projects { get; set; }
    
    public DbSet<Sprint> Sprints { get; set; }
    
    public DbSet<UserStory> UserStories { get; set; }
    
    public DbSet<TechnicalTask> TechnicalTasks { get; set; }
}