using FluentValidation;

namespace VB.HotChocoBoard.Application.Tasks.Create;

public class CreateTechnicalTaskCommandValidator : AbstractValidator<CreateTechnicalTaskCommand>
{
    public CreateTechnicalTaskCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("Task title is required.")
            .WithErrorCode("TASK_TITLE_REQUIRED");

        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("Task description is required.")
            .WithErrorCode("TASK_DESCRIPTION_REQUIRED");

        RuleFor(x => x.UserStoryId)
            .GreaterThan(0)
            .WithMessage("User Story ID must be greater than zero.")
            .WithErrorCode("INVALID_USER_STORY_ID");

        RuleFor(x => x.EstimatedEffort)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Estimated effort cannot be negative.")
            .WithErrorCode("INVALID_ESTIMATED_EFFORT");

        RuleFor(x => x.CompletedHours)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Completed hours cannot be negative.")
            .WithErrorCode("INVALID_COMPLETED_HOURS");
    }
}
