using MediatR;
using Microsoft.EntityFrameworkCore;
using VB.HotChocoBoard.Domain.Abstraction;
using VB.HotChocoBoard.Domain.Abstraction.Results;
using VB.HotChocoBoard.Infrastructure.Data;

namespace VB.HotChocoBoard.Application.UserStories.Delete;

public class DeleteUserStoryCommandHandler(BoardDbContext context)
    : IRequestHandler<DeleteUserStoryCommand, CustomResult<bool>>
{
    public async Task<CustomResult<bool>> Handle(DeleteUserStoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var userStory = await context.UserStories.FirstOrDefaultAsync(us => us.Id == request.Id, cancellationToken);
            if (userStory == null)
            {
                return CustomResult<bool>
                    .Failure(new Error("USER_STORY_NOT_FOUND", $"User story with ID {request.Id} was not found."));
            }

            context.UserStories.Remove(userStory);
            await context.SaveChangesAsync(cancellationToken);
            
            return CustomResult<bool>.Success(true);
        }
        catch (Exception ex)
        {
            return CustomResult<bool>
                .Failure(new Error("USER_STORY_DELETE_FAILED", $"Failed to delete user story: {ex.Message}"));
        }
    }
}
