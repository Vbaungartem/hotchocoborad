using MediatR;
using Microsoft.EntityFrameworkCore;
using VB.HotChocoBoard.Domain.Abstraction;
using VB.HotChocoBoard.Domain.Abstraction.Results;
using VB.HotChocoBoard.Domain.UserStories.Entities;
using VB.HotChocoBoard.Infrastructure.Data;

namespace VB.HotChocoBoard.Application.UserStories.Create;

public class CreateUserStoryCommandHandler(BoardDbContext context)
    : IRequestHandler<CreateUserStoryCommand, CustomResult<int>>
{
    public async Task<CustomResult<int>> Handle(CreateUserStoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var projectExists = await context.Projects.AnyAsync(p => p.Id == request.ProjectId, cancellationToken);
            if (!projectExists)
            {
                return CustomResult<int>
                    .Failure(new Error("PROJECT_NOT_FOUND", $"Project with ID {request.ProjectId} was not found."));
            }

            if (request.SprintId.HasValue)
            {
                var sprintExists = await context.Sprints.AnyAsync(s => s.Id == request.SprintId.Value, cancellationToken);
                if (!sprintExists)
                {
                    return CustomResult<int>
                        .Failure(new Error("SPRINT_NOT_FOUND", $"Sprint with ID {request.SprintId.Value} was not found."));
                }
            }

            var userStory = new UserStory(
                request.ProjectId,
                request.Title,
                request.Description,
                request.Priority,
                request.SprintId);

            context.UserStories.Add(userStory);
            await context.SaveChangesAsync(cancellationToken);

            return CustomResult<int>.Success(userStory.Id);
        }
        catch (Exception ex)
        {
            return CustomResult<int>
                .Failure(new Error("USER_STORY_CREATE_FAILED", $"Failed to create user story: {ex.Message}"));
        }
    }
}
