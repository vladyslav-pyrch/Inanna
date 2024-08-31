namespace Inanna.LibraryContext.Infrastructure.DataAccess.Models;

public class VolumeModel
{
    public int Id { get; set; }
    
    public string Title { get; set; }
    
    public string Number { get; set; }
    
    public MangaModel Manga { get; set; }
    
    public int MangaId { get; set; }
    
    public IEnumerable<ChapterModel> Chapters { get; set; }
}