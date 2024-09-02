using Inanna.Core.Domain.Model;

namespace Inanna.LibraryContext.Domain.Model.Mangas;

public record Publisher : ValueObject
{
    private readonly int _id;

    public Publisher(int id)
    {
        Id = id;
    }

    public int Id
    {
        get => _id;
        private init
        {
            if (int.IsNegative(value))
                throw new ArgumentException("Id cannot be negative.");

            _id = value;
        }
    }
}