using MediatR;
using VB.HotChocoBoard.Domain.Abstraction;
using VB.HotChocoBoard.Domain.Abstraction.Results;

namespace VB.HotChocoBoard.Application.Sprints.Update;

public record UpdateSprintCommand(int Id, string Name, DateTime StartDate, DateTime EndDate) : IRequest<CustomResult<int>>;
