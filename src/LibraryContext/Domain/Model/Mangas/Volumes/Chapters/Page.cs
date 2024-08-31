using Inanna.Core.Domain.Model;
using Inanna.LibraryContext.Domain.Model.Shared;

namespace Inanna.LibraryContext.Domain.Model.Mangas.Volumes.Chapters;

public record Page : ValueObject
{
    private readonly int _number;

    private readonly Image _image;

    public Page(int number, Image image)
    {
        Number = number;
        Image = image;
    }

    public int Number
    {
        get => _number;
        private init
        {
            if (int.IsNegative(value))
                throw new ArgumentException("Page number cannot be negative.");

            _number = value;
        }
    }

    public Image Image
    {
        get => _image;
        private init => _image = value ?? throw new ArgumentException("Page image cannot be null.");
    }
}