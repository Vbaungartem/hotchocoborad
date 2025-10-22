using MediatR;
using Microsoft.EntityFrameworkCore;
using VB.HotChocoBoard.Domain.Abstraction;
using VB.HotChocoBoard.Domain.Abstraction.Results;
using VB.HotChocoBoard.Infrastructure.Data;

namespace VB.HotChocoBoard.Application.Sprints.Delete;

public class DeleteSprintCommandHandler : IRequestHandler<DeleteSprintCommand, CustomResult<bool>>
{
    private readonly BoardDbContext _context;
    public DeleteSprintCommandHandler(BoardDbContext context)
    {
        _context = context;
    }
    public async Task<CustomResult<bool>> Handle(DeleteSprintCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var sprint = await _context.Sprints.FirstOrDefaultAsync(s => s.Id == request.Id, cancellationToken);
            if (sprint == null)
            {
                return CustomResult<bool>
                    .Failure(new Error("SPRINT_NOT_FOUND", $"Sprint with ID {request.Id} was not found."));
            }

            _context.Sprints.Remove(sprint);
            await _context.SaveChangesAsync(cancellationToken);
            
            return CustomResult<bool>.Success(true);
        }
        catch (Exception ex)
        {
            return CustomResult<bool>
                .Failure(new Error("SPRINT_DELETE_FAILED", $"Failed to delete sprint: {ex.Message}"));
        }
    }
}
