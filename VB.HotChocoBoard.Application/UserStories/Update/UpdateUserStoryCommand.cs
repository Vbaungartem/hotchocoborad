using MediatR;
using VB.HotChocoBoard.Domain.Abstraction;
using VB.HotChocoBoard.Domain.Abstraction.Results;
using VB.HotChocoBoard.Domain.UserStories.Enums;

namespace VB.HotChocoBoard.Application.UserStories.Update;

public record UpdateUserStoryCommand(int Id, string Title, string Description, Priority Priority, int? SprintId = null) : IRequest<CustomResult<int>>;
