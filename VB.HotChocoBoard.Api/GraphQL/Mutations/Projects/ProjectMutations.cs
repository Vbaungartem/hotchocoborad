using MediatR;
using VB.BookStore.Api.GraphQL.Mutations;
using VB.HotChocoBoard.Application.Projects.Create;
using VB.HotChocoBoard.Application.Projects.Update;
using VB.HotChocoBoard.Application.Projects.Delete;

namespace VB.BookStore.Api.GraphQL.Mutations.Projects;

[ExtendObjectType(nameof(Mutation))]
public class ProjectMutations
{
    public async Task<ProjectMutationResult> CreateProjectAsync(
        CreateProjectInput input,
        [Service] IMediator mediator,
        CancellationToken cancellationToken)
    {
        var command = new CreateProjectCommand(input.Name, input.Description);
        var result = await mediator.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return new ProjectMutationResult
            {
                Success = false,
                ErrorCode = result.Error!.Code,
                ErrorMessage = result.Error.Message
            };
        }

        return new ProjectMutationResult
        {
            Success = true,
            ProjectId = result.Data
        };
    }

    public async Task<ProjectMutationResult> UpdateProjectAsync(
        UpdateProjectInput input,
        [Service] IMediator mediator,
        CancellationToken cancellationToken)
    {
        var command = new UpdateProjectCommand(input.Id, input.Name, input.Description);
        var result = await mediator.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return new ProjectMutationResult
            {
                Success = false,
                ErrorCode = result.Error!.Code,
                ErrorMessage = result.Error.Message
            };
        }

        return new ProjectMutationResult
        {
            Success = true,
            ProjectId = result.Data
        };
    }

    public async Task<DeleteMutationResult> DeleteProjectAsync(
        DeleteProjectInput input,
        [Service] IMediator mediator,
        CancellationToken cancellationToken)
    {
        var command = new DeleteProjectCommand(input.Id);
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
public record CreateProjectInput(string Name, string Description);
public record UpdateProjectInput(int Id, string Name, string Description);
public record DeleteProjectInput(int Id);

// Result Types
public class ProjectMutationResult
{
    public bool Success { get; set; }
    public int? ProjectId { get; set; }
    public string? ErrorCode { get; set; }
    public string? ErrorMessage { get; set; }
}

public class DeleteMutationResult
{
    public bool Success { get; set; }
    public bool? Deleted { get; set; }
    public string? ErrorCode { get; set; }
    public string? ErrorMessage { get; set; }
}
