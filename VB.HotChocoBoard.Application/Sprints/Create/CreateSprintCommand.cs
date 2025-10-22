using MediatR;
using VB.HotChocoBoard.Domain.Abstraction;
using VB.HotChocoBoard.Domain.Abstraction.Results;

namespace VB.HotChocoBoard.Application.Sprints.Create;

public record CreateSprintCommand(int ProjectId, string Name, DateTime StartDate, DateTime EndDate) : IRequest<CustomResult<int>>;
