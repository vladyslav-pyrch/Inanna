using Inanna.Core.Domain.Model;

namespace Inanna.LibraryContext.Domain.Model.Mangas;

public record Genre : ValueObject
{
    private readonly string _name;

    public Genre(string name)
    {
        Name = name;
    }

    public string Name
    {
        get => _name;
        private init
        {
            BusynessRuleException.ThrowIfNullOrWhiteSpace(value, "Genre name cannot be null or white space.");
            BusynessRuleException.ThrowIfShorterThan(value, 20, "Name cannot be longer than 20 characters.");

            _name = value;
        }
    }
}