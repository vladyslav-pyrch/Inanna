using FluentValidation;
using Inanna.LibraryContext.Application.Validation;
using Inanna.LibraryContext.Domain;

namespace Inanna.LibraryContext.Application.Features.Mangas.Commands.Update;

public class UpdateChapterCommandValidator : AbstractValidator<UpdateChapterCommand>
{
    public UpdateChapterCommandValidator()
    {
        RuleFor(command => command.Title)
            .HaveMatchWithRegex(MyRegexes.Trimmed())
            .MaximumLength(100);
        RuleFor(command => command.Number)
            .HaveMatchWithRegex(MyRegexes.Trimmed())
            .HaveMatchWithRegex(MyRegexes.NumberRegex());
    }
}