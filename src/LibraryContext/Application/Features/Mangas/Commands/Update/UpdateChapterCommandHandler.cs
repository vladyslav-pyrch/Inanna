using Inanna.Core.Messaging;
using Inanna.LibraryContext.Domain.Model.Mangas;
using MediatR;

namespace Inanna.LibraryContext.Application.Features.Mangas.Commands.Update;

public class UpdateChapterCommandHandler(IMangaRepository mangaRepository, IPublisher publisher) : ICommandHandler<UpdateChapterCommand>
{
    public async Task Handle(UpdateChapterCommand request, CancellationToken cancellationToken)
    {
        var mangaId = new MangaId(request.MangaId);
        var volumeId = new VolumeId(request.VolumeId);
        var chapterId = new ChapterId(request.ChapterId);

        Manga manga = await mangaRepository.GetById(mangaId, cancellationToken);
        
        if (request is { Title: not null })
            manga.ChangeChapterTitle(volumeId, chapterId, request.Title);
        if (request is { Number: not null })
            manga.ChangeChapterNumber(volumeId, chapterId, request.Number);

        await manga.PublishEvents(publisher);
    }
}