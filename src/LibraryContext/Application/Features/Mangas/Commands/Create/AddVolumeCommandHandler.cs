using Inanna.Core.Messaging;
using Inanna.LibraryContext.Domain.Model.Mangas;
using MediatR;

namespace Inanna.LibraryContext.Application.Features.Mangas.Commands.Create;

public class AddVolumeCommandHandler(IPublisher publisher, IMangaRepository mangaRepository) : ICommandHandler<AddVolumeCommand, VolumeId>
{
    public async Task<VolumeId> Handle(AddVolumeCommand request, CancellationToken cancellationToken)
    {
        Manga manga = await mangaRepository.GetById(request.MangaId, cancellationToken);
        var volumeId = new VolumeId(Guid.NewGuid());
        
        manga.AddVolume(volumeId, request.Title, request.Number);

        await manga.PublishEvents(publisher);

        return volumeId;
    }
}