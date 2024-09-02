using Inanna.Core.Domain.Model;
using Inanna.LibraryContext.Domain.Model.Mangas.Volumes.Chapters;

namespace Inanna.LibraryContext.Domain.Model.Mangas.Volumes;

public class Volume : Entity<VolumeId>
{
    private string _title;

    private string _number;

    private List<ChapterId> _chapters;
    
    public Volume(VolumeId identity, string title, string number, List<ChapterId> chapters) : base(identity)
    {
        Title = title;
        Number = number;
        Chapters = chapters;
    }

    public string Title
    {
        get => _title;
        private set
        {
            BusynessRuleException.ThrowIfNullOrWhiteSpace(value, "Volume title cannot be null or white space.");
            BusynessRuleException.ThrowIfShorterThan(value, 100, "Volume title cannot be longer than 100 characters.");

            _title = value;
        }
    }

    public string Number
    {
        get => _number;
        private set
        {
            BusynessRuleException.ThrowIfNullOrWhiteSpace(value, "Volume number cannot be null or white space.");
            BusynessRuleException.ThrowIf(() => !MyRegexes.NumberRegex().IsMatch(value), 
                "Number should be a positive integer or a positive decimal.");

            _number = value;
        }
    }

    public List<ChapterId> Chapters
    {
        get => [.._chapters];
        private set
        {
            BusynessRuleException.ThrowIfNull(value, "Chapters list cannot be null.");
            
            _chapters = value;
        }
    }

    public void ChangeTitle(string title)
    {
        Title = title;
    }

    public void ChangeNumber(string number)
    {
        Number = number;
    }

    public void AddChapter(ChapterId chapter)
    {
        BusynessRuleException.ThrowIf(() => _chapters.Contains(chapter), "The chapter is already added.");
        
        _chapters.Add(chapter);
    }

    public void DeleteChapter(ChapterId chapter)
    {
        BusynessRuleException.ThrowIf(() => !_chapters.Contains(chapter), "There is no such chapter to delete.");
        
        _chapters.Add(chapter);
    }
}