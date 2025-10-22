using MediatR;
using Microsoft.EntityFrameworkCore;
using VB.HotChocoBoard.Domain.Abstraction;
using VB.HotChocoBoard.Domain.Abstraction.Results;
using VB.HotChocoBoard.Infrastructure.Data;

namespace VB.HotChocoBoard.Application.Tasks.Delete;

public class DeleteTechnicalTaskCommandHandler(BoardDbContext context)
    : IRequestHandler<DeleteTechnicalTaskCommand, CustomResult<bool>>
{
    public async Task<CustomResult<bool>> Handle(DeleteTechnicalTaskCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var task = await context.TechnicalTasks.FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);
            if (task == null)
            {
                return CustomResult<bool>
                    .Failure(new Error("TASK_NOT_FOUND", $"Technical task with ID {request.Id} was not found."));
            }

            context.TechnicalTasks.Remove(task);
            await context.SaveChangesAsync(cancellationToken);
            
            return CustomResult<bool>
                .Success(true);
        }
        catch (Exception ex)
        {
            return CustomResult<bool>
                .Failure(new Error("TASK_DELETE_FAILED", $"Failed to delete technical task: {ex.Message}"));
        }
    }
}
