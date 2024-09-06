namespace Inanna.LibraryContext.Infrastructure.DataAccess.Models;

internal class VolumeModel
{
    public int Id { get; set; }
    
    public string Title { get; set; }
    
    public string Number { get; set; }
    
    public MangaModel Manga { get; set; }
    
    public int? MangaId { get; set; }
    
    public ICollection<ChapterModel> Chapters { get; set; }
}