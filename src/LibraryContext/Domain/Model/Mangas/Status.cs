using Inanna.Core.Domain.Model;

namespace Inanna.LibraryContext.Domain.Model.Mangas;

public record Status : ValueObject
{
    private const string _publishing = "Publishing";

    private const string _completed = "Completed";

    private const string _deprecated = "Deprecated";

    private Status(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static Status Publishing => new(_publishing);

    public static Status Completed => new(_completed);

    public static Status Deprecated => new(_deprecated);

    public Status Parse(string status)
    {
        return status switch
        {
            _publishing => Publishing,
            _completed => Completed,
            _deprecated => Deprecated,
            _ => throw new ArgumentException("Cannot parse the status from the string.")
        };
    }

}