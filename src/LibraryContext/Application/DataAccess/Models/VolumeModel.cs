namespace Inanna.LibraryContext.Application.DataAccess.Models;

internal class VolumeModel
{
    public int Id { get; set; }
    
    public string Title { get; set; }
    
    public string Number { get; set; }
    
    public int? MangaId { get; set; }
}