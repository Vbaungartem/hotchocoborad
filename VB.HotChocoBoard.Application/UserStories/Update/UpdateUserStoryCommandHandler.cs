using MediatR;
using Microsoft.EntityFrameworkCore;
using VB.HotChocoBoard.Domain.Abstraction;
using VB.HotChocoBoard.Domain.Abstraction.Results;
using VB.HotChocoBoard.Infrastructure.Data;

namespace VB.HotChocoBoard.Application.UserStories.Update;

public class UpdateUserStoryCommandHandler(BoardDbContext context)
    : IRequestHandler<UpdateUserStoryCommand, CustomResult<int>>
{
    public async Task<CustomResult<int>> Handle(UpdateUserStoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var userStory = await context.UserStories.FirstOrDefaultAsync(us => us.Id == request.Id, cancellationToken);
            if (userStory == null)
            {
                return CustomResult<int>
                    .Failure(new Error("USER_STORY_NOT_FOUND", $"User story with ID {request.Id} was not found."));
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

            userStory.Update(request.Title, request.Description, request.Priority, request.SprintId);
            await context.SaveChangesAsync(cancellationToken);

            return CustomResult<int>.Success(userStory.Id);
        }
        catch (Exception ex)
        {
            return CustomResult<int>
                .Failure(new Error("USER_STORY_UPDATE_FAILED", $"Failed to update user story: {ex.Message}"));
        }
    }
}
