namespace Inanna.LibraryContext.Application.Features.Mangas.Projections;

public class ChapterProjection : IProjection
{
    public Guid Id { get; set; }
    
    public string Title { get; set; }
    
    public string Number { get; set; }
    
    public Guid VolumeId { get; set; }
}