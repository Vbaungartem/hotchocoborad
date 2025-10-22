using MediatR;
using VB.HotChocoBoard.Domain.Abstraction;
using VB.HotChocoBoard.Domain.Abstraction.Results;

namespace VB.HotChocoBoard.Application.Tasks.Delete;

public record DeleteTechnicalTaskCommand(int Id) : IRequest<CustomResult<bool>>;
