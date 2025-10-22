using MediatR;
using VB.HotChocoBoard.Domain.Abstraction;
using VB.HotChocoBoard.Domain.Abstraction.Results;
using VB.HotChocoBoard.Domain.Projects.Entities;
using VB.HotChocoBoard.Infrastructure.Data;

namespace VB.HotChocoBoard.Application.Projects.Create;

public class CreateProjectCommandHandler(BoardDbContext context) : IRequestHandler<CreateProjectCommand, CustomResult<int>>
{
    public async Task<CustomResult<int>> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var project = new Project(request.Name, request.Description);
            
            context.Projects.Add(project);
            
            await context.SaveChangesAsync(cancellationToken);
            
            return CustomResult<int>.Success(project.Id);
        }
        catch (Exception ex)
        {
            return CustomResult<int>
                .Failure(new Error("PROJECT_CREATE_FAILED", $"Failed to create project: {ex.Message}"));
        }
    }
}
