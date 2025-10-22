using MediatR;
using VB.BookStore.Api.GraphQL.Mutations;
using VB.BookStore.Api.GraphQL.Mutations.Projects;
using VB.HotChocoBoard.Application.UserStories.Create;
using VB.HotChocoBoard.Application.UserStories.Update;
using VB.HotChocoBoard.Application.UserStories.Delete;
using VB.HotChocoBoard.Domain.UserStories.Enums;

namespace VB.BookStore.Api.GraphQL.Mutations.UserStories;

[ExtendObjectType(nameof(Mutation))]
public class UserStoryMutations
{
    public async Task<UserStoryMutationResult> CreateUserStoryAsync(
        CreateUserStoryInput input,
        [Service] IMediator mediator,
        CancellationToken cancellationToken)
    {
        var command = new CreateUserStoryCommand(input.ProjectId, input.Title, input.Description, input.Priority, input.SprintId);
        var result = await mediator.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return new UserStoryMutationResult
            {
                Success = false,
                ErrorCode = result.Error!.Code,
                ErrorMessage = result.Error.Message
            };
        }

        return new UserStoryMutationResult
        {
            Success = true,
            UserStoryId = result.Data
        };
    }

    public async Task<UserStoryMutationResult> UpdateUserStoryAsync(
        UpdateUserStoryInput input,
        [Service] IMediator mediator,
        CancellationToken cancellationToken)
    {
        var command = new UpdateUserStoryCommand(input.Id, input.Title, input.Description, input.Priority, input.SprintId);
        var result = await mediator.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return new UserStoryMutationResult
            {
                Success = false,
                ErrorCode = result.Error!.Code,
                ErrorMessage = result.Error.Message
            };
        }

        return new UserStoryMutationResult
        {
            Success = true,
            UserStoryId = result.Data
        };
    }

    public async Task<DeleteMutationResult> DeleteUserStoryAsync(
        DeleteUserStoryInput input,
        [Service] IMediator mediator,
        CancellationToken cancellationToken)
    {
        var command = new DeleteUserStoryCommand(input.Id);
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
public record CreateUserStoryInput(int ProjectId, string Title, string Description, Priority Priority, int? SprintId = null);
public record UpdateUserStoryInput(int Id, string Title, string Description, Priority Priority, int? SprintId = null);
public record DeleteUserStoryInput(int Id);

// Result Types
public class UserStoryMutationResult
{
    public bool Success { get; set; }
    public int? UserStoryId { get; set; }
    public string? ErrorCode { get; set; }
    public string? ErrorMessage { get; set; }
}
