using MediatR;
using VB.HotChocoBoard.Domain.Abstraction;
using VB.HotChocoBoard.Domain.Abstraction.Results;
using VB.HotChocoBoard.Domain.UserStories.Enums;

namespace VB.HotChocoBoard.Application.UserStories.Create;

public record CreateUserStoryCommand(int ProjectId, string Title, string Description, Priority Priority, int? SprintId = null) : IRequest<CustomResult<int>>;
