using FluentValidation;

namespace VB.HotChocoBoard.Application.Projects.Update;

public class UpdateProjectCommandValidator : AbstractValidator<UpdateProjectCommand>
{
    public UpdateProjectCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("Project ID must be greater than zero.")
            .WithErrorCode("INVALID_PROJECT_ID");

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
