using MediatR;
using VB.HotChocoBoard.Domain.Abstraction;
using VB.HotChocoBoard.Domain.Abstraction.Results;

namespace VB.HotChocoBoard.Application.Projects.Create;

public record CreateProjectCommand(string Name, string Description) : IRequest<CustomResult<int>>;
