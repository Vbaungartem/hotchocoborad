using MediatR;
using VB.HotChocoBoard.Domain.Abstraction;
using VB.HotChocoBoard.Domain.Abstraction.Results;

namespace VB.HotChocoBoard.Application.Projects.Update;

public record UpdateProjectCommand(int Id, string Name, string Description) : IRequest<CustomResult<int>>;
