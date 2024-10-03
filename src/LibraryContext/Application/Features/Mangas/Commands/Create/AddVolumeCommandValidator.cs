using FluentValidation;
using Inanna.LibraryContext.Application.Validation;
using Inanna.LibraryContext.Domain;

namespace Inanna.LibraryContext.Application.Features.Mangas.Commands.Create;

public class AddVolumeCommandValidator : AbstractValidator<AddVolumeCommand>
{
    public AddVolumeCommandValidator()
    {
        RuleFor(command => command.Title).NotEmpty().MaximumLength(100);
        RuleFor(command => command.Number).NotEmpty().HaveMatchWithRegex(MyRegexes.NumberRegex());
    }
}