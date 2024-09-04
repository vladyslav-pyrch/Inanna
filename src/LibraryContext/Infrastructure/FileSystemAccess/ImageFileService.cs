using Inanna.LibraryContext.Domain.Model.Shared;

namespace Inanna.LibraryContext.Infrastructure.FileSystemAccess;

public class ImageFileService : IImageFileService
{
    private readonly string _imageRootPath = null!;

    public ImageFileService(string imageRootPath)
    {
        ImageRootPath = imageRootPath;
    }

    private string ImageRootPath
    {
        get => _imageRootPath;
        init
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value);

            _imageRootPath = value;
        }
    }

    public async Task<Image> SaveImage(byte[] imageBytes, string imageContentType)
    {
        string filePath = MadeFilePath(imageContentType);

        await File.WriteAllBytesAsync(filePath, imageBytes);

        return new Image(filePath, imageContentType);
    }

    public Task<byte[]> LoadImage(Image image)
    {
        return File.ReadAllBytesAsync(image.Path);
    }

    public Task DeleteImage(Image image)
    {
        return Task.Run(() => File.Delete(image.Path));
    }

    private string MadeFilePath(string imageContentType) => Path.ChangeExtension(
            Path.Combine(ImageRootPath, Path.GetRandomFileName()),
            GetExtension(imageContentType)
        );

    private string GetExtension(string contentType)
    {
        return contentType.Split('/')[1];
    }
}