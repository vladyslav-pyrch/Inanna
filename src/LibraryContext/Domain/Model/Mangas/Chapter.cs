using Inanna.Core.Domain.Model;

namespace Inanna.LibraryContext.Domain.Model.Mangas;

public class Chapter : Entity<ChapterId>
{
    private string _title;

    private string _number;
    
    private readonly List<Page> _pages = [];

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
            BusynessRuleException.ThrowIfNullOrWhiteSpace(value, "Chapter number cannot be null or white space.");
            BusynessRuleException.ThrowIf(() => !MyRegexes.NumberRegex().IsMatch(value), 
                "Number should be a positive integer or a positive decimal.");
            
            _number = value;
        }
    }

    public IReadOnlyList<Page> Pages => _pages.AsReadOnly();
}