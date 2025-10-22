using FluentValidation;

namespace VB.HotChocoBoard.Application.UserStories.Delete;

public class DeleteUserStoryCommandValidator : AbstractValidator<DeleteUserStoryCommand>
{
    public DeleteUserStoryCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("User story ID must be greater than zero.")
            .WithErrorCode("INVALID_USER_STORY_ID");
    }
}
