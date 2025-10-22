namespace VB.BookStore.Api.GraphQL.Queries.Sprints.Objects;

public sealed record SprintData(int Id, string Name, DateTime StartDate, DateTime EndDate)
{
    public static SprintData FromEntity(HotChocoBoard.Domain.Sprints.Entities.Sprint sprint) =>
        new(sprint.Id,
            sprint.Name,
            sprint.StartDate,
            sprint.EndDate);
}