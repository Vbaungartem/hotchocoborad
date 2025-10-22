using FluentValidation;

namespace VB.HotChocoBoard.Application.Projects.Create;

public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
{
    public CreateProjectCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Project name is required.")
            .WithErrorCode("PROJECT_NAME_REQUIRED");

        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("Project description is required.")
            .WithErrorCode("PROJECT_DESCRIPTION_REQUIRED");
    }
}
