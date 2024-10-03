using Inanna.Core.Messaging;
using Inanna.LibraryContext.Domain.Model.Mangas;
using MediatR;

namespace Inanna.LibraryContext.Application.Features.Mangas.Commands.Delete;

public class RemoveVolumeCommandHandler(IMangaRepository mangaRepository, IPublisher publisher) : ICommandHandler<RemoveVolumeCommand>
{
    public async Task Handle(RemoveVolumeCommand request, CancellationToken cancellationToken)
    {
        var mangaId = new MangaId(request.MangaId);
        var volumeId = new VolumeId(request.VolumeId);
        
        Manga manga = await mangaRepository.GetById(mangaId, cancellationToken);
        manga.RemoveVolume(volumeId);

        await manga.PublishEvents(publisher);
    }
}