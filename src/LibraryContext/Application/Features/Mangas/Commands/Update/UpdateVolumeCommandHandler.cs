using Inanna.Core.Messaging;
using Inanna.LibraryContext.Domain.Model.Mangas;
using MediatR;

namespace Inanna.LibraryContext.Application.Features.Mangas.Commands.Update;

public class UpdateVolumeCommandHandler(IMangaRepository mangaRepository, IPublisher publisher) : ICommandHandler<UpdateVolumeCommand>
{
    public async Task Handle(UpdateVolumeCommand request, CancellationToken cancellationToken)
    {
        var mangaId = new MangaId(request.MangaId);
        var volumeId = new VolumeId(request.VolumeId);
        
        Manga manga = await mangaRepository.GetById(mangaId, cancellationToken);
        
        if (request is { Number:not null })
            manga.ChangeVolumeNumber(volumeId, request.Number);
        if (request is { Title:not null })
            manga.ChangeVolumeTitle(volumeId, request.Title);

        await manga.PublishEvents(publisher);
    }
}