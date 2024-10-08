﻿using Inanna.Core.Domain.Model;

namespace Inanna.LibraryContext.Domain.Model.Mangas.Events;

public record GenreAdded(string GenreName) : Event<MangaId>;