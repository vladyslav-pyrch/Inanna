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
            BusynessRuleException.ThrowIfNullOrWhiteSpace(value, "Volume title cannot be null or white space.");
            BusynessRuleException.ThrowIfLongerThan(value, 100, "Volume title cannot be longer than 100 characters.");

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

    public IReadOnlyList<Chapter> Chapters => _chapters.Values.ToList().AsReadOnly();
}