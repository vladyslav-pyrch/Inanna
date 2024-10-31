using Inanna.Core.Messaging;
using Inanna.LibraryContext.Domain.Model.Mangas;
using Inanna.LibraryContext.Domain.Model.Mangas.Events;
using MediatR;

namespace Inanna.LibraryContext.Application.Features.Mangas.Commands.Delete;

public class DeleteMangaCommandHandler(IPublisher publisher) : ICommandHandler<DeleteMangaCommand>
{
    public async Task Handle(DeleteMangaCommand request, CancellationToken cancellationToken)
    {
        var mangaId = new MangaId(request.MangaId);
        
        var mangaDeleted = new MangaDeleted(mangaId)
        {
            AggregateRootId = mangaId,
            OccuredOn = DateTime.UtcNow
        };

        await publisher.Publish(mangaDeleted);
    }
}