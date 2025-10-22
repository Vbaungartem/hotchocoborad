using HotChocolate;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using VB.HotChocoBoard.Domain.Projects.Entities;
using VB.HotChocoBoard.Infrastructure.Data;

namespace VB.BookStore.Api.GraphQL.Queries.Projects;

public sealed class ProjectQueries : Query
{
    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Project> GetProjects([Service] BoardDbContext context)
    {
        return context
            .Set<Project>()
            .AsNoTrackingWithIdentityResolution()
            .AsQueryable();
    }
    
    public Task<Project?> GetProjectByIdAsync(
        int id,
        [Service] BoardDbContext context,
        CancellationToken cancellationToken)
    {
        return context
            .Set<Project>()
            .AsNoTracking()
            .FirstOrDefaultAsync(project => project.Id == id, cancellationToken);
    }
}