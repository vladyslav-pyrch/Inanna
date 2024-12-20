﻿using Inanna.Core.Messaging;
using Inanna.LibraryContext.Domain.Model.Mangas;

namespace Inanna.LibraryContext.Application.Features.Mangas.Commands.Delete;

public record RemoveChapterCommand(Guid MangaId, Guid VolumeId, Guid ChapterId) : ICommand;