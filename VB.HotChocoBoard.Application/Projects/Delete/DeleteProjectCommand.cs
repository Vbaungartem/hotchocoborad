using MediatR;
using VB.HotChocoBoard.Domain.Abstraction;
using VB.HotChocoBoard.Domain.Abstraction.Results;

namespace VB.HotChocoBoard.Application.Projects.Delete;

public record DeleteProjectCommand(int Id) : IRequest<CustomResult<bool>>;
