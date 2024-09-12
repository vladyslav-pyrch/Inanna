using Inanna.LibraryContext.Application.Features.Mangas.Projections.Repositories;

namespace Inanna.LibraryContext.Application.Features.Mangas;

public class MangasProjectionsUnitOfWork(
    IMangaProjectionsRepository mangaProjectionsRepository,
    IVolumeProjectionsRepository volumeProjectionsRepository,
    IChapterProjectionsRepository chapterProjectionsRepository,
    IPageProjectionsRepository pageProjectionsRepository,
    IGenreProjectionsRepository genreProjectionsRepository,
    IGenreToMangaProjectionsRepository genreToMangaProjectionsRepository)
{
    public IMangaProjectionsRepository MangaProjectionsRepository { get; } = mangaProjectionsRepository;

    public IVolumeProjectionsRepository VolumeProjectionsRepository { get; } = volumeProjectionsRepository;

    public IChapterProjectionsRepository ChapterProjectionsRepository { get; } = chapterProjectionsRepository;

    public IPageProjectionsRepository PageProjectionsRepository { get; } = pageProjectionsRepository;

    public IGenreProjectionsRepository GenreProjectionsRepository { get; } = genreProjectionsRepository;

    public IGenreToMangaProjectionsRepository GenreToMangaProjectionsRepository { get; } =
        genreToMangaProjectionsRepository;
}