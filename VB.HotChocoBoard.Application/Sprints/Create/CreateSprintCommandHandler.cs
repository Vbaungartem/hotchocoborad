using MediatR;
using Microsoft.EntityFrameworkCore;
using VB.HotChocoBoard.Domain.Abstraction;
using VB.HotChocoBoard.Domain.Abstraction.Results;
using VB.HotChocoBoard.Domain.Sprints.Entities;
using VB.HotChocoBoard.Infrastructure.Data;

namespace VB.HotChocoBoard.Application.Sprints.Create;

public class CreateSprintCommandHandler(BoardDbContext context) : IRequestHandler<CreateSprintCommand, CustomResult<int>>
{
    public async Task<CustomResult<int>> Handle(CreateSprintCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var projectExists = await context.Projects.AnyAsync(p => p.Id == request.ProjectId, cancellationToken);
            
            if (!projectExists)
            {
                return CustomResult<int>
                    .Failure(new Error("PROJECT_NOT_FOUND", $"Project with ID {request.ProjectId} was not found."));
            }

            var sprint = new Sprint(request.ProjectId, request.Name, request.StartDate, request.EndDate);
            
            context.Sprints.Add(sprint);
            
            await context.SaveChangesAsync(cancellationToken);
            
            return CustomResult<int>.Success(sprint.Id);
        }
        catch (Exception ex)
        {
            return CustomResult<int>
                .Failure(new Error("SPRINT_CREATE_FAILED", $"Failed to create sprint: {ex.Message}"));
        }
    }
}
