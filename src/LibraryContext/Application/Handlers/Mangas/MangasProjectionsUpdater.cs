using Inanna.Core.Domain.Model;
using Inanna.LibraryContext.Application.Features.Mangas;
using Inanna.LibraryContext.Application.Features.Mangas.Projections;
using Inanna.LibraryContext.Domain.Model.Mangas;
using Inanna.LibraryContext.Domain.Model.Mangas.Events;

namespace Inanna.LibraryContext.Application.Handlers.Mangas;

public class MangasProjectionsUpdater(MangasProjectionsUnitOfWork unitOfWork) :
    IEventHandler<MangaCreated, MangaId>,
    IEventHandler<MangaTitleChanged, MangaId>,
    IEventHandler<MangaCoverChanged, MangaId>,
    IEventHandler<MangaStateChanged, MangaId>,
    IEventHandler<GenreAdded, MangaId>,
    IEventHandler<GenreRemoved, MangaId>,
    IEventHandler<VolumeAdded, MangaId>,
    IEventHandler<VolumeRemoved, MangaId>,
    IEventHandler<VolumeTitleChanged, MangaId>,
    IEventHandler<VolumeNumberChanged, MangaId>,
    IEventHandler<ChapterAdded, MangaId>,
    IEventHandler<ChapterRemoved, MangaId>,
    IEventHandler<ChapterTitleChanged, MangaId>,
    IEventHandler<ChapterNumberChanged, MangaId>,
    IEventHandler<PageAdded, MangaId>,
    IEventHandler<PageRemoved, MangaId>
{
    // ToDo: if a projection is null, retrieve the aggregate and add data from it. 
    
    public async Task Handle(MangaCreated mangaCreated, CancellationToken cancellationToken) =>
        await unitOfWork.MangaProjections
            .Create(new MangaProjection
            {
                Id = mangaCreated.MangaId.Value,
                Title = mangaCreated.Title,
                State = mangaCreated.State.ToString()
            }, cancellationToken);

    public async Task Handle(MangaTitleChanged mangaTitleChanged, CancellationToken cancellationToken)
    {
        MangaProjection? mangaProjection = await unitOfWork.MangaProjections
            .Read(mangaTitleChanged.AggregateRootId.Value, cancellationToken);

        if (mangaProjection is null)
            return;
        
        mangaProjection.Title = mangaTitleChanged.Title;

        await unitOfWork.MangaProjections.Update(mangaProjection, cancellationToken);
    }

    public async Task Handle(MangaCoverChanged mangaCoverChanged, CancellationToken cancellationToken)
    {
        MangaProjection? mangaProjection = await unitOfWork.MangaProjections
            .Read(mangaCoverChanged.AggregateRootId.Value, cancellationToken);

        if (mangaProjection is null)
            return;
        
        if (mangaCoverChanged.Cover is not null)
            mangaProjection.Cover = new ImageProjection
            {
                ContentType = mangaCoverChanged.Cover.ContentType,
                Path = mangaCoverChanged.Cover.Path
            };
        else
            mangaProjection.Cover = null;

        await unitOfWork.MangaProjections.Update(mangaProjection, cancellationToken);
    }

    public async Task Handle(MangaStateChanged mangaStateChanged, CancellationToken cancellationToken)
    {
        MangaProjection? mangaProjection = await unitOfWork.MangaProjections
            .Read(mangaStateChanged.AggregateRootId.Value, cancellationToken);

        if (mangaProjection is null)
            return;
        
        mangaProjection.State = mangaStateChanged.State.ToString();

        await unitOfWork.MangaProjections.Update(mangaProjection, cancellationToken);
    }

    public async Task Handle(GenreAdded genreAdded, CancellationToken cancellationToken)
    {
        MangaProjection? mangaProjection = await unitOfWork.MangaProjections
            .Read(genreAdded.AggregateRootId.Value, cancellationToken);

        if (mangaProjection is null)
            return;
        
        GenreProjection? genreProjection = 
            await unitOfWork.GenreProjections.Read(genreAdded.GenreName, cancellationToken);

        if (genreProjection is null)
        {
            genreProjection = new GenreProjection { Name = genreAdded.GenreName };
            await unitOfWork.GenreProjections.Create(genreProjection, cancellationToken);
        }

        var genreToMangaProjection = new GenreToMangaProjection
        {
            GenreName = genreProjection.Name,
            MangaId = mangaProjection.Id
        };
        
        await unitOfWork.GenreToMangaProjections.Create(genreToMangaProjection, cancellationToken);
    }

    public async Task Handle(GenreRemoved genreRemoved, CancellationToken cancellationToken)
    {
        MangaProjection? mangaProjection = await unitOfWork.MangaProjections
            .Read(genreRemoved.AggregateRootId.Value, cancellationToken);

        if (mangaProjection is null)
            return;

        GenreToMangaProjection? genreToMangaProjection = await unitOfWork.GenreToMangaProjections
                .Read(new { mangaProjection.Id, genreRemoved.GenreName }, cancellationToken);
        
        if (genreToMangaProjection is null)
            return;

        await unitOfWork.GenreToMangaProjections
            .Delete(new { mangaProjection.Id, genreRemoved.GenreName }, cancellationToken);

        if (!unitOfWork.GenreToMangaProjections.Query()
                .Any(projection => projection.GenreName == genreRemoved.GenreName))
            await unitOfWork.GenreProjections.Delete(genreRemoved.GenreName, cancellationToken);
    }

    public async Task Handle(VolumeAdded volumeAdded, CancellationToken cancellationToken)
    {
        MangaProjection? mangaProjection = await unitOfWork.MangaProjections
            .Read(volumeAdded.AggregateRootId.Value, cancellationToken);

        if (mangaProjection is null)
            return;

        var volumeProjection = new VolumeProjection
        {
            Id = volumeAdded.VolumeId.Value,
            MangaId = mangaProjection.Id,
            Number = volumeAdded.Number,
            Title = volumeAdded.Title
        };

        await unitOfWork.VolumeProjections.Create(volumeProjection, cancellationToken);
    }

    public async Task Handle(VolumeRemoved volumeRemoved, CancellationToken cancellationToken) => 
        await unitOfWork.VolumeProjections.Delete(volumeRemoved.VolumeId.Value, cancellationToken);

    public async Task Handle(ChapterAdded chapterAdded, CancellationToken cancellationToken)
    {
        VolumeProjection? volumeProjection = await unitOfWork.VolumeProjections
            .Read(chapterAdded.VolumeId.Value, cancellationToken);
        
        if (volumeProjection is null)
            return;

        var chapterProjection = new ChapterProjection
        {
            Id = chapterAdded.ChapterId.Value,
            Title = chapterAdded.Title,
            Number = chapterAdded.Number,
            VolumeId = volumeProjection.Id
        };

        await unitOfWork.ChapterProjections.Create(chapterProjection, cancellationToken);
    }

    public async Task Handle(ChapterRemoved chapterRemoved, CancellationToken cancellationToken)
    {
        await unitOfWork.ChapterProjections.Delete(chapterRemoved.ChapterId, cancellationToken);
    }

    public async Task Handle(VolumeTitleChanged volumeTitleChanged, CancellationToken cancellationToken)
    {
        VolumeProjection? volumeProjection = await unitOfWork.VolumeProjections
            .Read(volumeTitleChanged.VolumeId.Value, cancellationToken);
        
        if (volumeProjection is null)
            return;

        volumeProjection.Title = volumeTitleChanged.Title;

        await unitOfWork.VolumeProjections.Update(volumeProjection, cancellationToken); 
    }

    public async Task Handle(VolumeNumberChanged volumeNumberChanged, CancellationToken cancellationToken)
    {
        VolumeProjection? volumeProjection = await unitOfWork.VolumeProjections
            .Read(volumeNumberChanged.VolumeId.Value, cancellationToken);
        
        if (volumeProjection is null)
            return;

        volumeProjection.Number = volumeNumberChanged.Number;

        await unitOfWork.VolumeProjections.Update(volumeProjection, cancellationToken);
    }

    public async Task Handle(ChapterTitleChanged chapterTitleChanged, CancellationToken cancellationToken)
    {
        ChapterProjection? chapterProjection = await unitOfWork.ChapterProjections
            .Read(chapterTitleChanged.ChapterId.Value, cancellationToken);
        
        if (chapterProjection is null)
            return;

        chapterProjection.Title = chapterTitleChanged.Title;

        await unitOfWork.ChapterProjections.Update(chapterProjection, cancellationToken);
    }

    public async Task Handle(ChapterNumberChanged chapterNumberChanged, CancellationToken cancellationToken)
    {
        ChapterProjection? chapterProjection = await unitOfWork.ChapterProjections
            .Read(chapterNumberChanged.ChapterId.Value, cancellationToken);
        
        if (chapterProjection is null)
            return;

        chapterProjection.Number = chapterNumberChanged.Number;

        await unitOfWork.ChapterProjections.Update(chapterProjection, cancellationToken);
    }

    public async Task Handle(PageAdded pageAdded, CancellationToken cancellationToken)
    {
        var pageProjection = new PageProjection
        {
            Number = pageAdded.PageNumber,
            ChapterId = pageAdded.ChapterId.Value,
            Image = new ImageProjection
            {
                Path = pageAdded.ImagePath,
                ContentType = pageAdded.ImageContentType
            }
        };

        await unitOfWork.PageProjections.Create(pageProjection, cancellationToken);
    }

    public Task Handle(PageRemoved notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}