using MediatR;
using Microsoft.EntityFrameworkCore;
using VB.HotChocoBoard.Domain.Abstraction;
using VB.HotChocoBoard.Domain.Abstraction.Results;
using VB.HotChocoBoard.Infrastructure.Data;

namespace VB.HotChocoBoard.Application.Projects.Update;

public class UpdateProjectCommandHandler(BoardDbContext context) : IRequestHandler<UpdateProjectCommand, CustomResult<int>>
{
    public async Task<CustomResult<int>> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var project = await context.Projects.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
            if (project == null)
            {
                return CustomResult<int>
                    .Failure(new Error("PROJECT_NOT_FOUND", $"Project with ID {request.Id} was not found."));
            }

            project.Update(request.Name, request.Description);
            await context.SaveChangesAsync(cancellationToken);
            
            return CustomResult<int>.Success(project.Id);
        }
        catch (Exception ex)
        {
            return CustomResult<int>
                .Failure(new Error("PROJECT_UPDATE_FAILED", $"Failed to update project: {ex.Message}"));
        }
    }
}
