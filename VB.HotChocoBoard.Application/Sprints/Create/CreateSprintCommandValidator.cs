using FluentValidation;

namespace VB.HotChocoBoard.Application.Sprints.Create;

public class CreateSprintCommandValidator : AbstractValidator<CreateSprintCommand>
{
    public CreateSprintCommandValidator()
    {
        RuleFor(x => x.ProjectId)
            .GreaterThan(0)
            .WithMessage("Project ID must be greater than zero.")
            .WithErrorCode("INVALID_PROJECT_ID");

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Sprint name is required.")
            .WithErrorCode("SPRINT_NAME_REQUIRED");

        RuleFor(x => x.StartDate)
            .LessThan(x => x.EndDate)
            .WithMessage("Start date must be before end date.")
            .WithErrorCode("INVALID_DATE_RANGE");
    }
}
