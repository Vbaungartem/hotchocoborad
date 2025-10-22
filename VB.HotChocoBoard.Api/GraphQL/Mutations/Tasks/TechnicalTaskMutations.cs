using MediatR;
using VB.BookStore.Api.GraphQL.Mutations.Projects;
using VB.HotChocoBoard.Application.Tasks.Create;
using VB.HotChocoBoard.Application.Tasks.Update;
using VB.HotChocoBoard.Application.Tasks.Delete;
using VB.HotChocoBoard.Domain.Abstraction.Results;
using VB.HotChocoBoard.Domain.Tasks.Enums;
using VBResults = VB.HotChocoBoard.Domain.Abstraction;

namespace VB.BookStore.Api.GraphQL.Mutations.Tasks;

[ExtendObjectType(nameof(Mutation))]
public class TechnicalTaskMutations
{
    public async Task<int> CreateTechnicalTaskAsync(
        CreateTechnicalTaskCommand input,
        [Service] IMediator mediator,
        CancellationToken cancellationToken)
    {
        var result = await mediator.Send(input, cancellationToken);

        return result.Data;
    }


    public Task<CustomResult<int>> UpdateTechnicalTaskAsync(
        UpdateTechnicalTaskCommand input,
        [Service] IMediator mediator,
        CancellationToken cancellationToken)
        => mediator.Send(input, cancellationToken);

    public async Task<DeleteMutationResult> DeleteTechnicalTaskAsync(
        DeleteTechnicalTaskInput input,
        [Service] IMediator mediator,
        CancellationToken cancellationToken)
    {
        var command = new DeleteTechnicalTaskCommand(input.Id);
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
public record CreateTechnicalTaskInput(
    string Title,
    string Description,
    int UserStoryId,
    int EstimatedEffort,
    int CompletedHours,
    Status Status);

public record UpdateTechnicalTaskInput(
    int Id,
    string Title,
    string Description,
    int EstimatedEffort,
    int CompletedHours,
    Status Status);

public record DeleteTechnicalTaskInput(int Id);

// Result Types
public class TechnicalTaskMutationResult
{
    public bool Success { get; set; }
    public int? TechnicalTaskId { get; set; }
    public string? ErrorCode { get; set; }
    public string? ErrorMessage { get; set; }
}