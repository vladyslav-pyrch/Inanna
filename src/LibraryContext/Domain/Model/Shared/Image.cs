using Inanna.Core.Domain.Model;

namespace Inanna.LibraryContext.Domain.Model.Shared;

public record Image : ValueObject
{
    private readonly string _path;

    private readonly string _contentType;

    public Image(string path, string contentType)
    {
        Path = path;
        ContentType = contentType;
    }

    public string Path
    {
        get => _path;
        private init
        {
            BusynessRuleException.ThrowIfNullOrWhiteSpace(value, "Image path cannot be null or white space.");

            _path = value;
        }
    }

    public string ContentType
    {
        get => _contentType;
        private init
        {
            BusynessRuleException.ThrowIfNullOrWhiteSpace(value,
                "Image content type cannot be null or white space.");
            BusynessRuleException.ThrowIf(() => !MyRegexes.ImageContentTypeRegex().IsMatch(value), 
                "Image content type should be of format \"image/[smth]\"");

            _contentType = value;
        }
    }
}