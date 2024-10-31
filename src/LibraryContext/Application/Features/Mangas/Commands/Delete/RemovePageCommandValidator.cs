using FluentValidation;

namespace Inanna.LibraryContext.Application.Features.Mangas.Commands.Delete;

public class RemovePageCommandValidator : AbstractValidator<RemovePageCommand>
{
    public RemovePageCommandValidator()
    {
        RuleFor(command => command.PageNumber).GreaterThan(0);
    }
}