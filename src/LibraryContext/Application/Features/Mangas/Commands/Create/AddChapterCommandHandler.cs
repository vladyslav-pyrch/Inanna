using Inanna.Core.Messaging;
using Inanna.LibraryContext.Domain.Model.Mangas;
using MediatR;

namespace Inanna.LibraryContext.Application.Features.Mangas.Commands.Create;

public class AddChapterCommandHandler(IMangaRepository mangaRepository, IPublisher publisher) : ICommandHandler<AddChapterCommand, ChapterId>
{
    public async Task<ChapterId> Handle(AddChapterCommand request, CancellationToken cancellationToken)
    {
        var mangaId = new MangaId(request.MangaId);
        var volumeId = new VolumeId(request.VolumeId);
        var chapterId = new ChapterId(Guid.NewGuid());
        
        Manga manga = await mangaRepository.GetById(mangaId, cancellationToken);
        
        manga.AddChapter(volumeId, chapterId, request.Title, request.Number);

        await manga.PublishEvents(publisher);

        return chapterId;
    }
}