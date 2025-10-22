using MediatR;
using Microsoft.EntityFrameworkCore;
using VB.HotChocoBoard.Domain.Abstraction;
using VB.HotChocoBoard.Domain.Abstraction.Results;
using VB.HotChocoBoard.Infrastructure.Data;

namespace VB.HotChocoBoard.Application.Sprints.Update;

public class UpdateSprintCommandHandler(BoardDbContext context) : IRequestHandler<UpdateSprintCommand, CustomResult<int>>
{
    public async Task<CustomResult<int>> Handle(UpdateSprintCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var sprint = await context.Sprints.FirstOrDefaultAsync(s => s.Id == request.Id, cancellationToken);
            if (sprint == null)
            {
                return CustomResult<int>
                    .Failure(new Error("SPRINT_NOT_FOUND", $"Sprint with ID {request.Id} was not found."));
            }

            sprint.Update(request.Name, request.StartDate, request.EndDate);
            await context.SaveChangesAsync(cancellationToken);
            
            return CustomResult<int>.Success(sprint.Id);
        }
        catch (Exception ex)
        {
            return CustomResult<int>
                .Failure(new Error("SPRINT_UPDATE_FAILED", $"Failed to update sprint: {ex.Message}"));
        }
    }
}
