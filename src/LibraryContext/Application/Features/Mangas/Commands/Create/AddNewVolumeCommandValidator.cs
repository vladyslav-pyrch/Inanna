using FluentValidation;
using Inanna.LibraryContext.Application.Validation;
using Inanna.LibraryContext.Domain;

namespace Inanna.LibraryContext.Application.Features.Mangas.Commands.Create;

public class AddNewVolumeCommandValidator : AbstractValidator<AddNewVolumeCommand>
{
    public AddNewVolumeCommandValidator()
    {
        RuleFor(command => command.MangaId).GreaterThanOrEqualTo(0);
        RuleFor(command => command.Title).NotEmpty().MaximumLength(100);
        RuleFor(command => command.Number).NotNull().HaveMatchWithRegex(MyRegexes.NumberRegex());
    }
}