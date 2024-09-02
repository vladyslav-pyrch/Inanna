namespace Inanna.LibraryContext.Domain.Model.Shared;

public interface IImageService
{
    public Task<Image> SaveImage(byte[] imageBytes);

    public Task<byte[]> LoadImage(Image image);

    public Task DeleteImage(Image image);
}