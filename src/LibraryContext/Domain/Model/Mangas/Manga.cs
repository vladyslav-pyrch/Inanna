using Inanna.Core.Domain.Model;
using Inanna.LibraryContext.Domain.Model.Mangas.Volumes;
using Inanna.LibraryContext.Domain.Model.Shared;

namespace Inanna.LibraryContext.Domain.Model.Mangas;

public class Manga : Entity<MangaId>
{
    private string _title;

    private Image? _cover;

    private List<VolumeId> _volumes;

    private List<Genre> _genres;

    private Status _status;

    private Publisher _publisher;
    
    public Manga(MangaId identity, string title, Status status, Publisher publisher, Image? cover, List<Genre> genres, List<VolumeId> volumes) : base(identity)
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
            BusynessRuleException.ThrowIfNullOrWhiteSpace(value, "Title should not be null or white space.");
            BusynessRuleException.ThrowIfLongerThan(value, 100, "Title cannot be longer than 100 characters.");

            _title = value;
        }
    }

    public Image? Cover
    {
        get => _cover;
        private set => _cover = value;
    }

    public Status Status
    {
        get => _status;
        private set => _status = value;
    }

    public Publisher Publisher
    {
        get => _publisher;
        private set
        {
            BusynessRuleException.ThrowIfNull(value, "Publisher cannot be null.");
            
            _publisher = value;
        }
    }

    public List<VolumeId> Volumes
    {
        get => [.._volumes];
        private set
        {
            BusynessRuleException.ThrowIfNull(value, "Volumes list cannot be null.");

            _volumes = value;
        }
    }

    public List<Genre> Genres
    {
        get => [.._genres];
        private set
        {
            BusynessRuleException.ThrowIfNull(value, "Genres list cannot be null.");
            
            _genres = value;
        }
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
        BusynessRuleException.ThrowIf(() => _volumes.Contains(volume), "The volume is already added.");
        
        _volumes.Add(volume);
    }

    public void RemoveVolume(VolumeId volume)
    {
        BusynessRuleException.ThrowIf(() => !_volumes.Contains(volume), "There is no such volume to delete.");
        
        _volumes.Add(volume);
    }

    public void AddGenre(Genre genre)
    {
        BusynessRuleException.ThrowIf(() => _genres.Contains(genre), "The genre is already added.");
        
        _genres.Add(genre);
    }

    public void RemoveGenre(Genre genre)
    {
        BusynessRuleException.ThrowIf(() => !_genres.Contains(genre), "There is no such genre to delete.");
        
        _genres.Add(genre);
    }
}