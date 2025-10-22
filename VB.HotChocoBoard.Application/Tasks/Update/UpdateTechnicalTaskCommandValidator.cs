using FluentValidation;

namespace VB.HotChocoBoard.Application.Tasks.Update;

public class UpdateTechnicalTaskCommandValidator : AbstractValidator<UpdateTechnicalTaskCommand>
{
    public UpdateTechnicalTaskCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("Task ID must be greater than zero.")
            .WithErrorCode("INVALID_TASK_ID");

        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("Task title is required.")
            .WithErrorCode("TASK_TITLE_REQUIRED");

        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("Task description is required.")
            .WithErrorCode("TASK_DESCRIPTION_REQUIRED");

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
