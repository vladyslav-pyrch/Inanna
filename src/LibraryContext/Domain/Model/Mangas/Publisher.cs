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
            BusynessRuleException.ThrowIf(() => int.IsNegative(value), "Publisher id value cannot be negative.");

            _id = value;
        }
    }
}