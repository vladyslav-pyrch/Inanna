using FluentValidation;
using Inanna.LibraryContext.Application.Validation;
using Inanna.LibraryContext.Domain;
using Inanna.LibraryContext.Domain.Model.Mangas;

namespace Inanna.LibraryContext.Application.Features.Mangas.Commands.Create;

public class CreateMangaCommandValidator : AbstractValidator<CreateMangaCommand>
{
    public CreateMangaCommandValidator()
    {
        RuleFor(command => command.Title).NotEmpty()
            .HaveMatchWithRegex(MyRegexes.Trimmed())
            .MaximumLength(100);
        RuleFor(command => command.Genres).ForEach(element =>
        {
            element.NotEmpty()
                .HaveMatchWithRegex(MyRegexes.Trimmed())
                .MaximumLength(20);
        });
        RuleFor(command => command.State).IsEnumName(typeof(State));
        RuleFor(command => command.CoverImageContentType)
            .HaveMatchWithRegex(MyRegexes.Trimmed())
            .HaveMatchWithRegex(MyRegexes.ImageContentTypeRegex())
            .IsNotNullWhenNotNull(command => command.CoverImageBytes);
        RuleFor(command => command.CoverImageBytes)
            .IsNotNullWhenNotNull(command => command.CoverImageContentType);
    }
}