using VB.HotChocoBoard.Domain.Sprints.Entities;

namespace VB.BookStore.Api.GraphQL.Mappings;

public class SprintTypeMapping : ObjectType<Sprint>, ITypeMapper
{
    protected override void Configure(IObjectTypeDescriptor<Sprint> descriptor)
    {
        descriptor
            .Field(sprint => sprint.CreatedAt)
            .Ignore();
    }
}