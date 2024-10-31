using Inanna.Core.Domain.Model;

namespace Inanna.LibraryContext.Domain.Model.Mangas;

public class Volume : Entity<VolumeId>
{
    private string _title;

    private string _number;

    private readonly Dictionary<ChapterId, Chapter> _chapters = [];
    
    public Volume(VolumeId identity, string title, string number)
    {
        Identity = identity;
        Title = title;
        Number = number;
    }

    public string Title
    {
        get => _title;
        private set
        {
            BusynessRuleException.ThrowIfNullOrWhiteSpace(value, 
                "Volume title cannot be null or white space.");
            BusynessRuleException.ThrowIfLongerThan(value, 100, 
                $"Volume title cannot be longer than 100 characters: {value}");
            BusynessRuleException.ThrowIf(() => MyRegexes.Trimmed().IsMatch(value),
                "The title should be trimmed.");

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
                $"Number should be a positive integer or a positive decimal: {value}");
            BusynessRuleException.ThrowIf(() => MyRegexes.Trimmed().IsMatch(value),
                "The number should be trimmed.");

            _number = value;
        }
    }

    public IReadOnlyList<Chapter> Chapters => _chapters.Values.ToList().AsReadOnly();

    public Chapter Chapter(ChapterId chapterId) => _chapters[chapterId];

    internal void ChangeTitle(string newTitle) => Title = newTitle;

    internal void ChangeNumber(string newNumber) => Number = newNumber;

    internal void AddChapter(ChapterId chapterId, string title, string number)
    {
        BusynessRuleException.ThrowIf(() => _chapters.ContainsKey(chapterId),
            $"There already is a chapter withs such id: {chapterId.Value}");
        BusynessRuleException.ThrowIf(() => _chapters.Values.Any(chapter1 => chapter1.Number == number), 
            $"There already is a chapter withs such number: {number}");
        
        var chapter = new Chapter(chapterId, title, number);
        _chapters.Add(chapterId, chapter);
    }

    internal bool RemoveChapter(ChapterId chapterId)
    {
        return _chapters.Remove(chapterId);
    }

    internal void ChangeChapterTitle(ChapterId chapterId, string newTitle)
    {
        BusynessRuleException.ThrowIf(() => !_chapters.ContainsKey(chapterId),
            $"There is no chapter with such id: {chapterId.Value}");
        
        _chapters[chapterId].ChangeTitle(newTitle);
    }
    
    internal void ChangeChapterNumber(ChapterId chapterId, string newNumber)
    {
        BusynessRuleException.ThrowIf(() => !_chapters.ContainsKey(chapterId),
            $"There is no chapter with such id: {chapterId.Value}");
        BusynessRuleException.ThrowIf(() => _chapters.Values.Any(chapter => chapter.Number == newNumber),
            $"There already is a chapter with such number: {newNumber}");
        
        _chapters[chapterId].ChangeNumber(newNumber);
    }
    
    internal void AddPage(ChapterId chapterId, int pageNumber, string imagePath, string imageContentType)
    {
        BusynessRuleException.ThrowIf(() => !_chapters.ContainsKey(chapterId),
            $"There is no chapter with such id: {chapterId.Value}");
        
        _chapters[chapterId].AddPage(pageNumber, imagePath, imageContentType);
    }

    internal bool RemovePage(ChapterId chapterId, int pageNumber)
    {
        BusynessRuleException.ThrowIf(() => !_chapters.ContainsKey(chapterId),
            $"There is no chapter with such id: {chapterId.Value}");
        
        return _chapters[chapterId].RemovePage(pageNumber);
    }
}