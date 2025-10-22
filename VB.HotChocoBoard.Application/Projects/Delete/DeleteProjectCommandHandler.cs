using MediatR;
using Microsoft.EntityFrameworkCore;
using VB.HotChocoBoard.Domain.Abstraction;
using VB.HotChocoBoard.Domain.Abstraction.Results;
using VB.HotChocoBoard.Infrastructure.Data;

namespace VB.HotChocoBoard.Application.Projects.Delete;

public class DeleteProjectCommandHandler(BoardDbContext context) : IRequestHandler<DeleteProjectCommand, CustomResult<bool>>
{
    public async Task<CustomResult<bool>> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var project = await context.Projects
                .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
            
            if (project == null)
            {
                return CustomResult<bool>
                    .Failure(new Error("PROJECT_NOT_FOUND", $"Project with ID {request.Id} was not found."));
            }

            context.Projects.Remove(project);
            
            await context.SaveChangesAsync(cancellationToken);
            
            return CustomResult<bool>.Success(true);
        }
        catch (Exception ex)
        {
            return CustomResult<bool>
                .Failure(new Error("PROJECT_DELETE_FAILED", $"Failed to delete project: {ex.Message}"));
        }
    }
}
