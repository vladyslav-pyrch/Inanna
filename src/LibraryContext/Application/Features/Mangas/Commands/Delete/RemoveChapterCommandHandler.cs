using Inanna.Core.Messaging;
using Inanna.LibraryContext.Domain.Model.Mangas;
using MediatR;

namespace Inanna.LibraryContext.Application.Features.Mangas.Commands.Delete;

public class RemoveChapterCommandHandler(IMangaRepository mangaRepository, IPublisher publisher) : ICommandHandler<RemoveChapterCommand>
{
    public async Task Handle(RemoveChapterCommand request, CancellationToken cancellationToken)
    {
        var mangaId = new MangaId(request.MangaId);
        var volumeId = new VolumeId(request.VolumeId);
        var chapterId = new ChapterId(request.ChapterId);
        
        Manga manga = await mangaRepository.GetById(mangaId, cancellationToken);
        
        // Remove pages withour calling other commands
        
        manga.RemoveChapter(volumeId, chapterId);
        

        await manga.PublishEvents(publisher);
    }
}