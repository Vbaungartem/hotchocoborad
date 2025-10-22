using MediatR;
using Microsoft.EntityFrameworkCore;
using VB.HotChocoBoard.Domain.Abstraction;
using VB.HotChocoBoard.Domain.Abstraction.Results;
using VB.HotChocoBoard.Infrastructure.Data;

namespace VB.HotChocoBoard.Application.Tasks.Update;

public class UpdateTechnicalTaskCommandHandler(BoardDbContext context)
    : IRequestHandler<UpdateTechnicalTaskCommand, CustomResult<int>>
{
    public async Task<CustomResult<int>> Handle(UpdateTechnicalTaskCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var task = await context.TechnicalTasks.FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);
            if (task == null)
            {
                return CustomResult<int>
                    .Failure(new Error("TASK_NOT_FOUND", $"Technical task with ID {request.Id} was not found."));
            }

            task.Update(
                request.Title,
                request.Description,
                request.EstimatedEffort,
                request.CompletedHours,
                request.Status);
                
            await context.SaveChangesAsync(cancellationToken);
            
            return CustomResult<int>.Success(task.Id);
        }
        catch (Exception ex)
        {
            return CustomResult<int>
                .Failure(new Error("TASK_UPDATE_FAILED", $"Failed to update technical task: {ex.Message}"));
        }
    }
}
