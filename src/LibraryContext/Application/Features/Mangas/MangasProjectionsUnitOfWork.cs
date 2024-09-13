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
    public IMangaProjectionsRepository MangaProjections { get; } = mangaProjectionsRepository;

    public IVolumeProjectionsRepository VolumeProjections { get; } = volumeProjectionsRepository;

    public IChapterProjectionsRepository ChapterProjections { get; } = chapterProjectionsRepository;

    public IPageProjectionsRepository PageProjections { get; } = pageProjectionsRepository;

    public IGenreProjectionsRepository GenreProjections { get; } = genreProjectionsRepository;

    public IGenreToMangaProjectionsRepository GenreToMangaProjections { get; } = genreToMangaProjectionsRepository;
}