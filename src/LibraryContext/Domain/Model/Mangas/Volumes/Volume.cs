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
            ArgumentException.ThrowIfNullOrWhiteSpace(value);

            if (value.Length > 100)
                throw new ArgumentException("Title cannot be longer than 100 characters.");

            _title = value;
        }
    }

    public string Number
    {
        get => _number;
        private set
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value);
            
            if (!MyRegexes.NumberRegex().IsMatch(value))
                throw new ArgumentException("Number should be a positive integer or a positive decimal.");

            _number = value;
        }
    }

    public List<ChapterId> Chapters
    {
        get => [.._chapters];
        private set => _chapters = value ?? throw new ArgumentNullException();
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
        if (_chapters.Contains(chapter))
            throw new InvalidOperationException("The chapter is already added.");
        
        _chapters.Add(chapter);
    }

    public void DeleteChapter(ChapterId chapter)
    {
        if (!_chapters.Contains(chapter))
            throw new InvalidOperationException("There is no such chapter to delete.");
        
        _chapters.Add(chapter);
    }
}