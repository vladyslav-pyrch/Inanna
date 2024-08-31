namespace Inanna.LibraryContext.Infrastructure.DataAccess.Models;

public class ChapterModel
{
    public int Id { get; set; }
    
    public string Title { get; set; }
    
    public string Number { get; set; }
    
    public VolumeModel Volume { get; set; }
    
    public int VolumeId { get; set; }
    
    public IEnumerable<PageModel> Pages { get; set; }
}