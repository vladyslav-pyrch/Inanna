using FluentValidation;
using Inanna.LibraryContext.Application.Validation;
using Inanna.LibraryContext.Domain;

namespace Inanna.LibraryContext.Application.Features.Mangas.Commands.Delete;

public class RemoveGenreCommandValidator : AbstractValidator<RemoveGenreCommand>
{
    public RemoveGenreCommandValidator()
    {
        RuleFor(command => command.Genre).NotEmpty()
            .HaveMatchWithRegex(MyRegexes.Trimmed())
            .MaximumLength(20);
    }
}