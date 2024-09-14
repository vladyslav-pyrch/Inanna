using Inanna.Core.Domain.Model;
using Inanna.LibraryContext.Domain.Model.Mangas.Events;
using Inanna.LibraryContext.Domain.Model.Shared;

namespace Inanna.LibraryContext.Domain.Model.Mangas;

public class Manga : AggregateRoot<MangaId>
{
    private string _title;

    private Image? _cover;

    private readonly Dictionary<VolumeId, Volume> _volumes = [];

    private readonly List<Genre> _genres = [];

    private State _state;

    public Manga() { }

    public Manga(MangaId mangaId, string title, State state)
    {
        Identity = mangaId;
        Title = title.Trim();
        State = state;
        Enqueue(new MangaCreated(mangaId, title, state));
    }
    
    public string Title
    {
        get => _title;
        private set
        {
            BusynessRuleException.ThrowIfNullOrWhiteSpace(value, 
                "Title should not be null or white space");
            BusynessRuleException.ThrowIfLongerThan(value, 100,
                $"Title cannot be longer than 100 characters: {value}");

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
        get => _state;
        private set => _state = value;
    }

    public IReadOnlyList<Volume> Volumes => _volumes.Values.ToList().AsReadOnly();

    public IReadOnlyList<Genre> Genres => _genres.AsReadOnly();

    public void ChangeTitle(string newTitle)
    {
        string titleTrimmed = newTitle.Trim();
        
        Title = titleTrimmed;
        
        Enqueue(new MangaTitleChanged(titleTrimmed));
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
        string titleTrimmed = title.Trim();
        string numberTrimmed = number.Trim();
        var volume = new Volume(volumeId, titleTrimmed, numberTrimmed);
        
        BusynessRuleException.ThrowIf(() => _volumes.ContainsKey(volumeId),
            $"There already is a volume with such an id: {volumeId.Value}");
        BusynessRuleException.ThrowIf(() => _volumes.Values.Any(volume1 => volume1.Number == numberTrimmed),
            $"There already is a volume with such a number: {numberTrimmed}");
        
        _volumes.Add(volumeId, volume);
        
        Enqueue(new VolumeAdded(volumeId, titleTrimmed, numberTrimmed));
    }

    public void RemoveVolume(VolumeId volumeId)
    {
        BusynessRuleException.ThrowIf(() => !_volumes.ContainsKey(volumeId),
            $"There is no volume with such id: {volumeId.Value}, to remove");
        
        _volumes.Remove(volumeId);
        
        Enqueue(new VolumeRemoved(volumeId));
    }

    public void ChangeVolumeTitle(VolumeId volumeId, string title)
    {
        BusynessRuleException.ThrowIf(() => !_volumes.ContainsKey(volumeId),
            $"There is no volume with such id: {volumeId.Value}");

        string titleTrimmed = title.Trim();
        
        _volumes[volumeId].ChangeTitle(titleTrimmed);
        
        Enqueue(new VolumeTitleChanged(volumeId, titleTrimmed));
    }

    public void ChangeVolumeNumber(VolumeId volumeId, string number)
    {
        BusynessRuleException.ThrowIf(() => !_volumes.ContainsKey(volumeId),
            $"There is no volume with such id: {volumeId.Value}");

        string numberTrimmed = number.Trim();
        
        BusynessRuleException.ThrowIf(() => _volumes.Values.Any(volume1 => volume1.Number == numberTrimmed),
            $"There is a volume with such a number: {numberTrimmed}");
        
        _volumes[volumeId].ChangeNumber(numberTrimmed);
        
        Enqueue(new VolumeNumberChanged(volumeId, numberTrimmed));
    }

    public void AddChapter(VolumeId volumeId, ChapterId chapterId, string title, string number)
    {
        BusynessRuleException.ThrowIf(() => !_volumes.ContainsKey(volumeId),
            $"There is no volume with such id: {volumeId.Value}");

        string titleTrimmed = title.Trim();
        string numberTrimmed = number.Trim();
        
        _volumes[volumeId].AddChapter(chapterId, titleTrimmed, numberTrimmed);
        
        Enqueue(new ChapterAdded(volumeId, chapterId, titleTrimmed, numberTrimmed));
    }

    public void RemoveChapter(VolumeId volumeId, ChapterId chapterId)
    {
        BusynessRuleException.ThrowIf(() => !_volumes.ContainsKey(volumeId),
            $"There is no volume with such id: {volumeId.Value}");
        
        _volumes[volumeId].RemoveChapter(chapterId);
        
        Enqueue(new ChapterRemoved(volumeId, chapterId));
    }

    public void ChangeChapterTitle(VolumeId volumeId, ChapterId chapterId, string title)
    {
        BusynessRuleException.ThrowIf(() => !_volumes.ContainsKey(volumeId),
            $"There is no volume with such id: {volumeId.Value}");

        string titleTrimmed = title.Trim();
        
        _volumes[volumeId].ChangeChapterTitle(chapterId, titleTrimmed);
        
        Enqueue(new ChapterTitleChanged(volumeId, chapterId, titleTrimmed));
    }

    public void ChangeChapterNumber(VolumeId volumeId, ChapterId chapterId, string number)
    {
        BusynessRuleException.ThrowIf(() => !_volumes.ContainsKey(volumeId),
            $"There is no volume with such id: {volumeId.Value}");

        string numberTrimmed = number.Trim();
        
        _volumes[volumeId].ChangeChapterNumber(chapterId, numberTrimmed);
        
        Enqueue(new ChapterNumberChanged(volumeId, chapterId, numberTrimmed));
    }

    public void AddPage(VolumeId volumeId, ChapterId chapterId, int pageNumber, string imagePath,
        string imageContentType)
    {
        BusynessRuleException.ThrowIf(() => !_volumes.ContainsKey(volumeId),
            $"There is no volume with such id: {volumeId.Value}");
        BusynessRuleException.ThrowIf(() => pageNumber <= 0, 
            $"Page number may not be 0 or negative: {pageNumber}");

        string imagePathTrimmed = imagePath.Trim();
        string imageContentTypeTrimmed = imageContentType.Trim();
        
        _volumes[volumeId].AddPage(chapterId, pageNumber, imagePathTrimmed, imageContentTypeTrimmed);
        
        Enqueue(new PageAdded(volumeId, chapterId, pageNumber, imagePathTrimmed, imageContentTypeTrimmed));
    }

    public void RemovePage(VolumeId volumeId, ChapterId chapterId, int pageNumber)
    {
        BusynessRuleException.ThrowIf(() => !_volumes.ContainsKey(volumeId),
            $"There is no volume with such id: {volumeId.Value}");
        BusynessRuleException.ThrowIf(() => pageNumber <= 0, 
            $"Page number may not be 0 or negative: {pageNumber}");
        
        _volumes[volumeId].RemovePage(chapterId, pageNumber);
    }

    public void AddGenre(string genreName)
    {
        string genreNameTrimmed = genreName.Trim();
        
        var genre = new Genre(genreNameTrimmed);
        
        BusynessRuleException.ThrowIf(() => _genres.Contains(genre), 
            $"The genre is already added: {genreNameTrimmed}");
        
        _genres.Add(genre);
        
        Enqueue(new GenreAdded(genreNameTrimmed));
    }

    public void RemoveGenre(string genreName)
    {
        string genreNameTrimmed = genreName.Trim();

        var genre = new Genre(genreNameTrimmed);
        
        BusynessRuleException.ThrowIf(() => !_genres.Contains(genre), 
            $"There is no genre to delete: {genreNameTrimmed}");
        
        _genres.Remove(genre);
        
        Enqueue(new GenreRemoved(genreNameTrimmed));
    }

    protected override void Evolve(IEvent<MangaId> @event)
    {
        switch (@event)
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
            case VolumeTitleChanged volumeTitleChanged:
                _volumes[volumeTitleChanged.VolumeId].ChangeTitle(volumeTitleChanged.Title);
                break;
            case VolumeNumberChanged volumeNumberChanged:
                _volumes[volumeNumberChanged.VolumeId].ChangeNumber(volumeNumberChanged.Number);
                break;
            case ChapterAdded chapterAdded:
                _volumes[chapterAdded.VolumeId]
                    .AddChapter(chapterAdded.ChapterId, chapterAdded.Title, chapterAdded.Number);
                break;
            case ChapterRemoved chapterRemoved:
                _volumes[chapterRemoved.VolumeId].RemoveChapter(chapterRemoved.ChapterId);
                break;
            case ChapterTitleChanged chapterTitleChanged:
                _volumes[chapterTitleChanged.VolumeId]
                    .ChangeChapterTitle(chapterTitleChanged.ChapterId, chapterTitleChanged.Title);
                break;
            case ChapterNumberChanged chapterNumberChanged:
                _volumes[chapterNumberChanged.VolumeId]
                    .ChangeChapterNumber(chapterNumberChanged.ChapterId, chapterNumberChanged.Number);
                break;
            case PageAdded pageAdded:
                _volumes[pageAdded.VolumeId]
                    .AddPage(pageAdded.ChapterId, pageAdded.PageNumber, pageAdded.ImagePath, pageAdded.ImageContentType);
                break;
            case PageRemoved pageRemoved:
                _volumes[pageRemoved.VolumeId].RemovePage(pageRemoved.ChapterId, pageRemoved.PageNumber);
                break;
            case GenreAdded genreAdded:
                _genres.Add(new Genre(genreAdded.GenreName));
                break;
            case GenreRemoved genreRemoved:
                _genres.Remove(new Genre(genreRemoved.GenreName));
                break;
        }
    }
}