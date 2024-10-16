using FluentValidation;
using Inanna.LibraryContext.Application.Validation;
using Inanna.LibraryContext.Domain;

namespace Inanna.LibraryContext.Application.Features.Mangas.Commands.Create;

public class AddChapterCommandValidator : AbstractValidator<AddChapterCommand>
{
    public AddChapterCommandValidator()
    {
        RuleFor(command => command.Title).NotEmpty()
            .HaveMatchWithRegex(MyRegexes.Trimmed())
            .MaximumLength(100);
        RuleFor(command => command.Number).NotEmpty()
            .HaveMatchWithRegex(MyRegexes.Trimmed())
            .HaveMatchWithRegex(MyRegexes.NumberRegex());
    }
}