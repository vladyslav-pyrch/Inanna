namespace Inanna.LibraryContext.Domain.Model.Shared;

public interface IImageFileService
{
    public Task<Image> SaveImage(byte[] imageBytes, string imageContentType);

    public Task<byte[]> LoadImage(Image image);

    public Task DeleteImage(Image image);
}