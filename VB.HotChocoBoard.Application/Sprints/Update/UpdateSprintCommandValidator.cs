using FluentValidation;

namespace VB.HotChocoBoard.Application.Sprints.Update;

public class UpdateSprintCommandValidator : AbstractValidator<UpdateSprintCommand>
{
    public UpdateSprintCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("Sprint ID must be greater than zero.")
            .WithErrorCode("INVALID_SPRINT_ID");

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
