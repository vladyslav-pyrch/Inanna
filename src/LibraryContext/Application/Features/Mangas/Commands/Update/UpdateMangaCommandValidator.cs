using FluentValidation;
using Inanna.LibraryContext.Application.Validation;
using Inanna.LibraryContext.Domain;
using Inanna.LibraryContext.Domain.Model.Mangas;

namespace Inanna.LibraryContext.Application.Features.Mangas.Commands.Update;

public class UpdateMangaCommandValidator : AbstractValidator<UpdateMangaCommand>
{
    public UpdateMangaCommandValidator()
    {
        RuleFor(command => command.Title).MaximumLength(100);
        RuleFor(command => command.State).IsEnumName(typeof(State));
        RuleFor(command => command.CoverImageContentType)
            .HaveMatchWithRegex(MyRegexes.ImageContentTypeRegex())
            .IsNotNullWhenNotNull(command => command.CoverImageBytes);
        RuleFor(command => command.CoverImageBytes)
            .IsNotNullWhenNotNull(command => command.CoverImageContentType);
    }
}