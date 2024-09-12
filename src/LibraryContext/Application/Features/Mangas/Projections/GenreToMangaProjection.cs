namespace Inanna.LibraryContext.Application.Features.Mangas.Projections;

public class GenreToMangaProjection : IProjection
{
    public Guid MangaId { get; set; }
    
    public string GenreName { get; set; }
}