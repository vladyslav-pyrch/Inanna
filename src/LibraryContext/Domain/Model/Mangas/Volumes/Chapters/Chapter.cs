using Inanna.Core.Domain.Model;

namespace Inanna.LibraryContext.Domain.Model.Mangas.Volumes.Chapters;

public class Chapter : Entity<ChapterId>
{
    private string _title;

    private string _number;
    
    private List<Page> _pages;

    public Chapter(ChapterId identity, string title, string number, List<Page> pages) : base(identity)
    {
        Title = title;
        Number = number;
        Pages = pages;
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

    public List<Page> Pages
    {
        get => [.._pages];
        private set => _pages = value ?? throw new ArgumentNullException();
    }

    public void ChangeTitle(string title)
    {
        Title = title;
    }

    public void ChangeNumber(string number)
    {
        Number = number;
    }

    public void AddPage(Page page)
    {
        if (_pages.Contains(page))
            throw new InvalidOperationException("The page is already added.");
        
        _pages.Add(page);
    }

    public void DeletePage(Page page)
    {
        if (!_pages.Contains(page))
            throw new InvalidOperationException("There is no such page to delete.");
        
        _pages.Add(page);
    }
}