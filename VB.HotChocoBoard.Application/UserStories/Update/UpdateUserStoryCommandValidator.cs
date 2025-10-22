using FluentValidation;

namespace VB.HotChocoBoard.Application.UserStories.Update;

public class UpdateUserStoryCommandValidator : AbstractValidator<UpdateUserStoryCommand>
{
    public UpdateUserStoryCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("User story ID must be greater than zero.")
            .WithErrorCode("INVALID_USER_STORY_ID");

        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("User story title is required.")
            .WithErrorCode("USER_STORY_TITLE_REQUIRED");

        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("User story description is required.")
            .WithErrorCode("USER_STORY_DESCRIPTION_REQUIRED");

        RuleFor(x => x.SprintId)
            .GreaterThan(0)
            .When(x => x.SprintId.HasValue)
            .WithMessage("Sprint ID must be greater than zero when provided.")
            .WithErrorCode("INVALID_SPRINT_ID");
    }
}
