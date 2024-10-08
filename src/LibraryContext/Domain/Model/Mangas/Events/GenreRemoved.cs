﻿using Inanna.Core.Domain.Model;

namespace Inanna.LibraryContext.Domain.Model.Mangas.Events;

public record GenreRemoved(string GenreName) : Event<MangaId>;