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
        var state = Enum.Parse<State>(request.State);
        var mangaId = new MangaId(Guid.NewGuid());
        var manga = new Manga(mangaId, request.Title, state);
        
        foreach (string genre in request.Genres ?? [])
            manga.AddGenre(genre);

        if (request is { CoverImageBytes: not null, CoverImageContentType: not null })
        {
            string imagePath = await fileService.Save(request.CoverImageBytes, request.CoverImageContentType);
            manga.ChangeCover(new Image(imagePath, request.CoverImageContentType));
        }
        
        await manga.PublishEvents(publisher);

        return manga.Identity;
    }
}