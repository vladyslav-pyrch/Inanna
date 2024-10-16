using FluentValidation;
using Inanna.LibraryContext.Application.Validation;
using Inanna.LibraryContext.Domain;

namespace Inanna.LibraryContext.Application.Features.Mangas.Commands.Update;

public class UpdateVolumeCommandValidator : AbstractValidator<UpdateVolumeCommand>
{
    public UpdateVolumeCommandValidator()
    {
        RuleFor(command => command.Title)
            .HaveMatchWithRegex(MyRegexes.Trimmed())
            .MaximumLength(100);
        RuleFor(command => command.Number)
            .HaveMatchWithRegex(MyRegexes.Trimmed())
            .HaveMatchWithRegex(MyRegexes.NumberRegex());

    }
}