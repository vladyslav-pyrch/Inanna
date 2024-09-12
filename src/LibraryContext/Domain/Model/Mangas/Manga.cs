using Inanna.Core.Domain.Model;
using Inanna.LibraryContext.Domain.Model.Mangas.Events;
using Inanna.LibraryContext.Domain.Model.Shared;

namespace Inanna.LibraryContext.Domain.Model.Mangas;

public class Manga : AggregateRoot<MangaId>
{
    private string? _title;

    private Image? _cover;

    private readonly Dictionary<VolumeId, Volume> _volumes = [];

    private readonly List<Genre> _genres = [];

    private State? _state;

    public Manga() { }

    public Manga(MangaId mangaId)
    {
        Identity = mangaId;
        Enqueue(new MangaCreated(mangaId));
    }
    
    public string Title
    {
        get => _title ?? BusynessRuleException.AccessingUninitialisedState<string>();
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

    public State State
    {
        get => _state ?? BusynessRuleException.AccessingUninitialisedState<State>();
        private set => _state = value;
    }

    public IReadOnlyList<Volume> Volumes => _volumes.Values.ToList().AsReadOnly();

    public IReadOnlyList<Genre> Genres => _genres.AsReadOnly();

    public void ChangeTitle(string newTitle)
    {
        Title = newTitle;
        
        Enqueue(new MangaTitleChanged(newTitle));
    }

    public void ChangeCover(Image newCover)
    {
        Cover = newCover;
        
        Enqueue(new MangaCoverChanged(newCover));
    }

    public void ChangeState(State newState)
    {
        State = newState;
        
        Enqueue(new MangaStateChanged(newState));
    }

    public void AddVolume(VolumeId volumeId, string title, string number)
    {
        title = title.Trim();
        number = number.Trim();
        var volume = new Volume(volumeId, title, number);
        
        BusynessRuleException.ThrowIf(() => _volumes.ContainsKey(volumeId),
            "There is a volume with such an id: {id}", volumeId.Value);
        BusynessRuleException.ThrowIf(() => _volumes.Values.Any(volume1 => volume1.Title == title), 
            "There is volume with such a title: {title}", title);
        BusynessRuleException.ThrowIf(() => _volumes.Values.Any(volume1 => volume1.Number == number),
            "There is a volume with such a number: {number}", number);
        
        _volumes.Add(volumeId, volume);
        
        Enqueue(new VolumeAdded(volumeId, title, number));
    }

    public void RemoveVolume(VolumeId volumeId)
    {
        BusynessRuleException.ThrowIf(() => !_volumes.ContainsKey(volumeId),
            "There is no volume with such id: {id}, to delete", volumeId.Value);
        
        _volumes.Remove(volumeId);
        
        Enqueue(new VolumeRemoved(volumeId));
    }

    public void AddGenre(Genre genre)
    {
        BusynessRuleException.ThrowIf(() => _genres.Contains(genre), "The genre is already added");
        
        _genres.Add(genre);
        
        Enqueue(new GenreAdded(genre));
    }

    public void RemoveGenre(Genre genre)
    {
        BusynessRuleException.ThrowIf(() => !_genres.Contains(genre), "There is no genre to delete");
        
        _genres.Remove(genre);
        
        Enqueue(new GenreRemoved(genre));
    }

    protected override void Evolve(IDomainEvent<MangaId> domainEvent)
    {
        switch (domainEvent)
        {
            case MangaTitleChanged mangaTitleChanged:
                Title = mangaTitleChanged.Title;
                break;
            case MangaCoverChanged mangaCoverChanged:
                Cover = mangaCoverChanged.Cover;
                break;
            case MangaStateChanged mangaStateChanged:
                State = mangaStateChanged.State;
                break;
            case MangaCreated mangaCreated:
                Identity = mangaCreated.MangaId;
                break;
            case VolumeAdded volumeAdded:
                var volume = new Volume(volumeAdded.VolumeId, volumeAdded.Title, volumeAdded.Number);
                _volumes.Add(volumeAdded.VolumeId, volume);
                break;
            case VolumeRemoved volumeRemoved:
                _volumes.Remove(volumeRemoved.VolumeId);
                break;
            case GenreAdded genreAdded:
                _genres.Add(genreAdded.Genre);
                break;
            case GenreRemoved genreRemoved:
                _genres.Remove(genreRemoved.Genre);
                break;
        }
    }
}