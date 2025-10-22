using FluentValidation;

namespace VB.HotChocoBoard.Application.Projects.Delete;

public class DeleteProjectCommandValidator : AbstractValidator<DeleteProjectCommand>
{
    public DeleteProjectCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("Project ID must be greater than zero.")
            .WithErrorCode("INVALID_PROJECT_ID");
    }
}
