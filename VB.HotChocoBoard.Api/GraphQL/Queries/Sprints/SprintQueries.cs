using HotChocolate;
using HotChocolate.Data.Filters;
using HotChocolate.Data.Sorting;
using HotChocolate.Resolvers;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using VB.BookStore.Api.GraphQL.Queries.Sprints.Objects;
using VB.HotChocoBoard.Domain.Sprints.Entities;
using VB.HotChocoBoard.Infrastructure.Data;

namespace VB.BookStore.Api.GraphQL.Queries.Sprints;

public class SprintQueries : Query
{
    [UsePaging]
    [UseFiltering<FilterInputType<Sprint>>]
    [UseSorting<SortInputType<Sprint>>]
    public IQueryable<SprintData>  GetSprints(
        [Service] BoardDbContext context,
        IResolverContext resolverContext)
    {
        var query = context
            .Set<Sprint>()
            .AsNoTrackingWithIdentityResolution()
            .Filter(resolverContext)
            .Sort(resolverContext);
        
        return query.Select(sprint => SprintData.FromEntity(sprint));
    }
    
    public Task<Sprint?> GetSprintByIdAsync(
        int id,
        [Service] BoardDbContext context,
        CancellationToken cancellationToken)
    {
        return context
            .Set<Sprint>()
            .AsNoTracking()
            .FirstOrDefaultAsync(sprint => sprint.Id == id, cancellationToken);
    }
}