namespace Inanna.LibraryContext.Application.DataAccess.Models;

internal class ChapterModel
{
    public int Id { get; set; }
    
    public string Title { get; set; }
    
    public string Number { get; set; }
    
    public int? VolumeId { get; set; }
}