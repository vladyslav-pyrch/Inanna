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
    IEventHandler<VolumeRemoved, MangaId>
{
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
            await unitOfWork.GenreProjections.Read(genreAdded.Genre.Name, cancellationToken);

        if (genreProjection is null)
        {
            genreProjection = new GenreProjection { Name = genreAdded.Genre.Name };
            await unitOfWork.GenreProjections.Create(genreProjection, cancellationToken);
        }

        var genreToMangaProjection = new GenreToMangaProjection
        {
            GenreName = genreProjection.Name!,
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
                .Read(new { mangaProjection.Id, genreRemoved.Genre.Name }, cancellationToken);
        
        if (genreToMangaProjection is null)
            return;

        await unitOfWork.GenreToMangaProjections
            .Delete(new { mangaProjection.Id, genreRemoved.Genre.Name }, cancellationToken);

        if (!unitOfWork.GenreToMangaProjections.Query()
                .Any(projection => projection.GenreName == genreRemoved.Genre.Name))
            await unitOfWork.GenreProjections.Delete(genreRemoved.Genre, cancellationToken);
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
}