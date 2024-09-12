namespace Inanna.LibraryContext.Domain.Model.Shared;

public interface IFileService
{
    public Task<string> Save(byte[] bytes, string contentType);

    public Task<byte[]> Load(string path);

    public Task Delete(string path);
}