using HotChocolate;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using VB.HotChocoBoard.Domain.Tasks.Entities;
using VB.HotChocoBoard.Infrastructure.Data;

namespace VB.BookStore.Api.GraphQL.Queries.Tasks;

public sealed class TaskQueries : Query
{
    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<TechnicalTask> GetTasks([Service] BoardDbContext context)
    {
        return context
            .Set<TechnicalTask>()
            .AsNoTrackingWithIdentityResolution()
            .AsQueryable();
    }
    
    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public Task<TechnicalTask?> GetTaskById(
        int id,
        [Service] BoardDbContext context,
        CancellationToken cancellationToken)
    {
        return context
            .Set<TechnicalTask>()
            .AsNoTrackingWithIdentityResolution()
            .FirstOrDefaultAsync(task => task.Id == id, cancellationToken);
    }
}