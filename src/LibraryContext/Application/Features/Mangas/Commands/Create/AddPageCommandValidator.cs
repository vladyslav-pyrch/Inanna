using FluentValidation;
using Inanna.LibraryContext.Application.Validation;
using Inanna.LibraryContext.Domain;

namespace Inanna.LibraryContext.Application.Features.Mangas.Commands.Create;

public class AddPageCommandValidator : AbstractValidator<AddPageCommand>
{
    public AddPageCommandValidator()
    {
        RuleFor(command => command.PageNumber).GreaterThan(0);
        RuleFor(command => command.ImageContentType).NotNull()
            .HaveMatchWithRegex(MyRegexes.Trimmed())
            .HaveMatchWithRegex(MyRegexes.ImageContentTypeRegex());
        RuleFor(command => command.ImageBytes).NotNull();
    }
}