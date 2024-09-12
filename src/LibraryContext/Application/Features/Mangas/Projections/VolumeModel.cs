namespace Inanna.LibraryContext.Application.Features.Mangas.Projections;

public class VolumeProjection : IProjection
{
    public Guid Id { get; set; }
    
    public string Title { get; set; }
    
    public string Number { get; set; }
    
    public Guid? MangaId { get; set; }
}