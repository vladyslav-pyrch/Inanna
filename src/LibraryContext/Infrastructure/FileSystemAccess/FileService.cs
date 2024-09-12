using Inanna.LibraryContext.Domain.Model.Shared;

namespace Inanna.LibraryContext.Infrastructure.FileSystemAccess;

public class FileService : IFileService
{
    private readonly string _fileRootPath = null!;

    public FileService(string fileRootPath)
    {
        FileRootPath = fileRootPath;
    }

    private string FileRootPath
    {
        get => _fileRootPath;
        init
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value);

            _fileRootPath = value;
        }
    }

    public async Task<string> Save(byte[] bytes, string contentType)
    {
        string filePath = MadeFilePath(contentType);

        await File.WriteAllBytesAsync(filePath, bytes);

        return filePath;
    }

    public Task<byte[]> Load(string path)
    {
        return File.ReadAllBytesAsync(path);
    }

    public Task Delete(string path)
    {
        return Task.Run(() => File.Delete(path));
    }

    private string MadeFilePath(string contentType) => Path.ChangeExtension(
            Path.Combine(FileRootPath, Path.GetRandomFileName()),
            GetExtension(contentType)
        );

    private static string GetExtension(string contentType) => contentType.Split('/')[1];
}