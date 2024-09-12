using Inanna.Core.Messaging;
using Inanna.LibraryContext.Domain.Model.Mangas;
using Inanna.LibraryContext.Domain.Model.Shared;
using MediatR;

namespace Inanna.LibraryContext.Application.Features.Mangas.Commands.Create;

public class CreateMangaCommandHandler(IPublisher publisher, IFileService fileService)
    : ICommandHandler<CreateMangaCommand, MangaId>
{
    public async Task<MangaId> Handle(CreateMangaCommand request, CancellationToken cancellationToken)
    {
        var manga = new Manga(new MangaId(Guid.NewGuid()));
        manga.ChangeTitle(request.Title);
        manga.ChangeState(request.State);
        
        foreach (string genre in request.Genres ?? [])
            manga.AddGenre(new Genre(genre));

        if (request is { CoverImageBytes: not null, CoverImageContentType: not null })
        {
            string imagePath = await fileService.Save(request.CoverImageBytes, request.CoverImageContentType);
            manga.ChangeCover(new Image(imagePath, request.CoverImageContentType));
        }
        
        await manga.PublishDomainEvents(publisher);

        return manga.Identity;
    }
}