using MediatR;
using VB.BookStore.Api.GraphQL.Mutations;
using VB.BookStore.Api.GraphQL.Mutations.Projects;
using VB.HotChocoBoard.Application.Sprints.Create;
using VB.HotChocoBoard.Application.Sprints.Update;
using VB.HotChocoBoard.Application.Sprints.Delete;

namespace VB.BookStore.Api.GraphQL.Mutations.Sprints;

[ExtendObjectType(nameof(Mutation))]
public class SprintMutations
{
    public async Task<SprintMutationResult> CreateSprintAsync(
        CreateSprintInput input,
        [Service] IMediator mediator,
        CancellationToken cancellationToken)
    {
        var command = new CreateSprintCommand(input.ProjectId, input.Name, input.StartDate, input.EndDate);
        var result = await mediator.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return new SprintMutationResult
            {
                Success = false,
                ErrorCode = result.Error!.Code,
                ErrorMessage = result.Error.Message
            };
        }

        return new SprintMutationResult
        {
            Success = true,
            SprintId = result.Data
        };
    }

    public async Task<SprintMutationResult> UpdateSprintAsync(
        UpdateSprintInput input,
        [Service] IMediator mediator,
        CancellationToken cancellationToken)
    {
        var command = new UpdateSprintCommand(input.Id, input.Name, input.StartDate, input.EndDate);
        var result = await mediator.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return new SprintMutationResult
            {
                Success = false,
                ErrorCode = result.Error!.Code,
                ErrorMessage = result.Error.Message
            };
        }

        return new SprintMutationResult
        {
            Success = true,
            SprintId = result.Data
        };
    }

    public async Task<DeleteMutationResult> DeleteSprintAsync(
        DeleteSprintInput input,
        [Service] IMediator mediator,
        CancellationToken cancellationToken)
    {
        var command = new DeleteSprintCommand(input.Id);
        var result = await mediator.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return new DeleteMutationResult
            {
                Success = false,
                ErrorCode = result.Error!.Code,
                ErrorMessage = result.Error.Message
            };
        }

        return new DeleteMutationResult
        {
            Success = true,
            Deleted = result.Data
        };
    }
}

// Input Types
public record CreateSprintInput(int ProjectId, string Name, DateTime StartDate, DateTime EndDate);
public record UpdateSprintInput(int Id, string Name, DateTime StartDate, DateTime EndDate);
public record DeleteSprintInput(int Id);

// Result Types
public class SprintMutationResult
{
    public bool Success { get; set; }
    public int? SprintId { get; set; }
    public string? ErrorCode { get; set; }
    public string? ErrorMessage { get; set; }
}
