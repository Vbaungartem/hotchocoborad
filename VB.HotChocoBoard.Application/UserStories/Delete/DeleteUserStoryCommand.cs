using MediatR;
using VB.HotChocoBoard.Domain.Abstraction;
using VB.HotChocoBoard.Domain.Abstraction.Results;

namespace VB.HotChocoBoard.Application.UserStories.Delete;

public record DeleteUserStoryCommand(int Id) : IRequest<CustomResult<bool>>;
