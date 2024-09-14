namespace Inanna.LibraryContext.Application.Features.Mangas.Projections;

public class PageProjection : IProjection
{
    public int Number { get; set; }
    
    public ImageProjection Image { get; set; }
    
    public Guid ChapterId { get; set; }
}