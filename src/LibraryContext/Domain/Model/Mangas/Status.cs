using Inanna.Core.Domain.Model;

namespace Inanna.LibraryContext.Domain.Model.Mangas;

public record Status : ValueObject
{
    private readonly string _value;

    private Status(string value)
    {
        _value = value;
    }

    public static Status Publishing => new("Publishing");

    public static Status Completed => new("Completed");

    public static Status Deprecated => new("Deprecated");

}