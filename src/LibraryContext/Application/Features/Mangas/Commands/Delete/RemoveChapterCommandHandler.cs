using Inanna.Core.Messaging;
using Inanna.LibraryContext.Domain.Model.Mangas;
using MediatR;

namespace Inanna.LibraryContext.Application.Features.Mangas.Commands.Delete;

public class RemoveChapterCommandHandler(IMangaRepository mangaRepository, IPublisher publisher) : ICommandHandler<RemoveChapterCommand>
{
    public async Task Handle(RemoveChapterCommand request, CancellationToken cancellationToken)
    {
        Manga manga = await mangaRepository.GetById(request.MangaId, cancellationToken);
        
        manga.RemoveChapter(request.VolumeId, request.ChapterId);

        await manga.PublishEvents(publisher);
    }
}