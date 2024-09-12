namespace Inanna.LibraryContext.Application.Features.Mangas.Projections;

public class ImageProjection : IProjection
{
    public string Path { get; set; }
    
    public string ContentType { get; set; }
}