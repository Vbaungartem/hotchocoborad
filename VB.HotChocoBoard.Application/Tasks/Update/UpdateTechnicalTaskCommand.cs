using MediatR;
using VB.HotChocoBoard.Domain.Abstraction;
using VB.HotChocoBoard.Domain.Abstraction.Results;
using VB.HotChocoBoard.Domain.Tasks.Enums;

namespace VB.HotChocoBoard.Application.Tasks.Update;

public record UpdateTechnicalTaskCommand(
    int Id,
    string Title,
    string Description,
    int EstimatedEffort,
    int CompletedHours,
    Status Status) : IRequest<CustomResult<int>>;
