using FluentValidation;
using Inanna.LibraryContext.Application.Validation;
using Inanna.LibraryContext.Domain;

namespace Inanna.LibraryContext.Application.Features.Mangas.Commands.Create;

public class CreateMangaCommandValidator : AbstractValidator<CreateMangaCommand>
{
    public CreateMangaCommandValidator()
    {
        RuleFor(command => command.Title).NotEmpty().MaximumLength(100);
        RuleFor(command => command.Genres).ForEach(element =>
        {
            element.NotEmpty().MaximumLength(20);
        });
        RuleFor(command => command.CoverImageContentType)
            .HaveMatchWithRegex(MyRegexes.ImageContentTypeRegex())
            .IsNotNullWhenNotNull(command => command.CoverImageBytes);
        RuleFor(command => command.CoverImageBytes)
            .IsNotNullWhenNotNull(command => command.CoverImageContentType);
    }
}