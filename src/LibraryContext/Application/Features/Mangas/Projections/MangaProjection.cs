namespace Inanna.LibraryContext.Application.Features.Mangas.Projections;

public class MangaProjection : IProjection
{
    public Guid Id { get; set; }
    
    public string Title { get; set; }
    
    public string State { get; set; }
    
    public ImageProjection? Cover { get; set; }
}