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
            ArgumentException.ThrowIfNullOrWhiteSpace(value);

            _path = value;
        }
    }

    public string ContentType
    {
        get => _contentType;
        private init
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value);

            if (!MyRegexes.ImageContentTypeRegex().IsMatch(value))
                throw new ArgumentException("Image content type should be of format \"image/[smth]\"");

            _contentType = value;
        }
    }
}