using FluentValidation;

namespace VB.HotChocoBoard.Application.Sprints.Delete;

public class DeleteSprintCommandValidator : AbstractValidator<DeleteSprintCommand>
{
    public DeleteSprintCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("Sprint ID must be greater than zero.")
            .WithErrorCode("INVALID_SPRINT_ID");
    }
}
