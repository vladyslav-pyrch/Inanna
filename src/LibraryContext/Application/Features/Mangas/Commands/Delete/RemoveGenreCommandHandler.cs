using Inanna.Core.Messaging;
using Inanna.LibraryContext.Domain.Model.Mangas;
using MediatR;

namespace Inanna.LibraryContext.Application.Features.Mangas.Commands.Delete;

public class RemoveGenreCommandHandler(IMangaRepository mangaRepository, IPublisher publisher) : ICommandHandler<RemoveGenreCommand>
{
    public async Task Handle(RemoveGenreCommand request, CancellationToken cancellationToken)
    {
        var mangaId = new MangaId(request.MangaId);

        Manga manga = await mangaRepository.GetById(mangaId, cancellationToken);
        
        manga.RemoveGenre(request.Genre);

        await manga.PublishEvents(publisher);
    }
}