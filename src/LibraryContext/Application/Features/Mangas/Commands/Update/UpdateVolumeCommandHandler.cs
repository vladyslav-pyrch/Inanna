using Inanna.Core.Messaging;
using Inanna.LibraryContext.Domain.Model.Mangas;
using MediatR;

namespace Inanna.LibraryContext.Application.Features.Mangas.Commands.Update;

public class UpdateVolumeCommandHandler(IMangaRepository mangaRepository, IPublisher publisher) : ICommandHandler<UpdateVolumeCommand>
{
    public async Task Handle(UpdateVolumeCommand request, CancellationToken cancellationToken)
    {
        Manga manga = await mangaRepository.GetById(request.MangaId, cancellationToken);
        
        if (request is { Number:not null })
            manga.ChangeVolumeNumber(request.VolumeId, request.Number);
        if (request is { Title:not null })
            manga.ChangeVolumeTitle(request.VolumeId, request.Title);

        await manga.PublishEvents(publisher);
    }
}