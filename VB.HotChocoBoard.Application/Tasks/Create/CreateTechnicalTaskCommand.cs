using MediatR;
using VB.HotChocoBoard.Domain.Abstraction;
using VB.HotChocoBoard.Domain.Abstraction.Results;
using VB.HotChocoBoard.Domain.Tasks.Enums;

namespace VB.HotChocoBoard.Application.Tasks.Create;

public record CreateTechnicalTaskCommand(
    string Title,
    string Description,
    int UserStoryId,
    int EstimatedEffort,
    int CompletedHours,
    Status Status) : IRequest<CustomResult<int>>;
