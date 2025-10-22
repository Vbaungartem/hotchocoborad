using FluentValidation;

namespace VB.HotChocoBoard.Application.Tasks.Delete;

public class DeleteTechnicalTaskCommandValidator : AbstractValidator<DeleteTechnicalTaskCommand>
{
    public DeleteTechnicalTaskCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("Task ID must be greater than zero.")
            .WithErrorCode("INVALID_TASK_ID");
    }
}
