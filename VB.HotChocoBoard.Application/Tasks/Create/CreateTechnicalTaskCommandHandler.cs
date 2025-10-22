using MediatR;
using Microsoft.EntityFrameworkCore;
using VB.HotChocoBoard.Domain.Abstraction;
using VB.HotChocoBoard.Domain.Abstraction.Results;
using VB.HotChocoBoard.Domain.Tasks.Entities;
using VB.HotChocoBoard.Infrastructure.Data;

namespace VB.HotChocoBoard.Application.Tasks.Create;

public class CreateTechnicalTaskCommandHandler(BoardDbContext context)
    : IRequestHandler<CreateTechnicalTaskCommand, CustomResult<int>>
{
    public async Task<CustomResult<int>> Handle(CreateTechnicalTaskCommand request, CancellationToken cancellationToken)
    {
        try
        {
            // Verify user story exists
            var userStoryExists = await context.UserStories.AnyAsync(us => us.Id == request.UserStoryId, cancellationToken);
            if (!userStoryExists)
            {
                return CustomResult<int>.Failure(new Error("USER_STORY_NOT_FOUND", $"User Story with ID {request.UserStoryId} was not found."));
            }

            var task = new TechnicalTask(
                request.Title,
                request.Description,
                request.UserStoryId,
                request.EstimatedEffort,
                request.CompletedHours,
                request.Status);

            context.TechnicalTasks.Add(task);
            await context.SaveChangesAsync(cancellationToken);

            return CustomResult<int>.Success(task.Id);
        }
        catch (Exception ex)
        {
            return CustomResult<int>
                .Failure(new Error("TASK_CREATE_FAILED", $"Failed to create technical task: {ex.Message}"));
        }
    }
}
