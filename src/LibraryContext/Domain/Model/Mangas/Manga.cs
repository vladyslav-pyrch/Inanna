using Inanna.Core.Domain.Model;
using Inanna.LibraryContext.Domain.Model.Mangas.Volumes;
using Inanna.LibraryContext.Domain.Model.Shared;

namespace Inanna.LibraryContext.Domain.Model.Mangas;

public class Manga : Entity<MangaId>
{
    private string _title;

    private Image _cover;

    private List<VolumeId> _volumes;

    private List<Genre> _genres;

    private Status _status;

    private Publisher _publisher;
    
    public Manga(MangaId identity, string title, Image cover, Status status, Publisher publisher, List<Genre> genres, List<VolumeId> volumes) : base(identity)
    {
        Title = title;
        Cover = cover;
        Volumes = volumes;
        Genres = genres;
        Status = status;
        Publisher = publisher;
    }

    public string Title
    {
        get => _title;
        private set
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value);

            if (value.Length > 100)
                throw new ArgumentException("Title cannot be longer than 100 characters.");

            _title = value;
        }
    }

    public Image Cover
    {
        get => _cover;
        private set => _cover = value ?? throw new ArgumentException("Cover cannot be null.");
    }

    public Status Status
    {
        get => _status;
        private set => _status = value ?? throw new ArgumentNullException();
    }

    public Publisher Publisher
    {
        get => _publisher;
        private set => _publisher = value ?? throw new ArgumentNullException();
    }
    
    public List<VolumeId> Volumes
    {
        get => [.._volumes];
        private set => _volumes = value ?? throw new ArgumentException("Volume list cannot be null.");
    }
    
    public List<Genre> Genres 
    {
        get => [.._genres];
        private set => _genres = value ?? throw new ArgumentException("Volume list cannot be null.");
    }

    public int NumberOfVolumes => _volumes.Count;

    public void ChangeTitle(string newTitle)
    {
        Title = newTitle;
    }

    public void ChangeCover(Image newCover)
    {
        Cover = newCover;
    }

    public void ChangeStatus(Status newStatus)
    {
        Status = newStatus;
    }

    public void ChangePublisher(Publisher newPublisher)
    {
        Publisher = newPublisher;
    }

    public void AddVolume(VolumeId volume)
    {
        if (_volumes.Contains(volume))
            throw new InvalidOperationException("The volume is already added.");
        
        _volumes.Add(volume);
    }

    public void RemoveVolume(VolumeId volume)
    {
        if (!_volumes.Contains(volume))
            throw new InvalidOperationException("There is no such volume to delete.");
        
        _volumes.Add(volume);
    }

    public void AddGenre(Genre genre)
    {
        if (_genres.Contains(genre))
            throw new InvalidOperationException("The genre is already added.");
        
        _genres.Add(genre);
    }

    public void RemoveGenre(Genre genre)
    {
        if (!_genres.Contains(genre))
            throw new InvalidOperationException("There is no such genre to delete.");
        
        _genres.Add(genre);
    }
}