using Inanna.Core.Domain.Model;
using Inanna.LibraryContext.Domain.Model.Shared;

namespace Inanna.LibraryContext.Domain.Model.Mangas;

public class Chapter : Entity<ChapterId>
{
    private string _title;

    private string _number;
    
    private readonly Dictionary<int, Page> _pages = [];

    public Chapter(ChapterId identity, string title, string number)
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
                "Chapter title cannot be null or white space.");
            BusynessRuleException.ThrowIf(() => !MyRegexes.Trimmed().IsMatch(value),
                "The title should be trimmed.");
            BusynessRuleException.ThrowIfLongerThan(value, 100,
                $"Title cannot be longer than 100 characters: {value}");

            _title = value;
        }
    }

    public string Number
    {
        get => _number;
        private set
        {
            BusynessRuleException.ThrowIfNullOrWhiteSpace(value, 
                "Chapter number cannot be null or white space.");
            BusynessRuleException.ThrowIf(() => !MyRegexes.NumberRegex().IsMatch(value), 
                $"Number should be a positive integer or a positive decimal: {value}");
            BusynessRuleException.ThrowIf(() => !MyRegexes.Trimmed().IsMatch(value),
                "The number should be trimmed");
            
            _number = value;
        }
    }

    public IReadOnlyList<Page> Pages => _pages.Values.ToList().AsReadOnly();

    public Page Page(int number) => _pages[number];

    internal void ChangeNumber(string newNumber) => Number = newNumber;

    internal void ChangeTitle(string newTitle) => Title = newTitle;

    internal void AddPage(int pageNumber, string imagePath, string imageContentType)
    {
        BusynessRuleException.ThrowIf(() => _pages.ContainsKey(pageNumber),
            $"There already is a page with such number: {pageNumber}");
        
        var image = new Image(imagePath, imageContentType);
        var page = new Page(pageNumber, image);
        
        _pages.Add(pageNumber, page);
    }

    internal bool RemovePage(int pageNumber)
    {
        return _pages.Remove(pageNumber);
    }
}