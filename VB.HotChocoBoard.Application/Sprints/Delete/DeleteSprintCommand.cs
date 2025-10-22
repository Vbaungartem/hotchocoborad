using MediatR;
using VB.HotChocoBoard.Domain.Abstraction;
using VB.HotChocoBoard.Domain.Abstraction.Results;

namespace VB.HotChocoBoard.Application.Sprints.Delete;

public record DeleteSprintCommand(int Id) : IRequest<CustomResult<bool>>;
