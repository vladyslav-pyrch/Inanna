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
            ArgumentException.ThrowIfNullOrWhiteSpace(value);

            if (value.Length > 20)
                throw new ArgumentException("Name cannot be longer than 20 characters.");

            _name = value;
        }
    }
}