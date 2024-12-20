﻿using Inanna.Core.Messaging;
using Inanna.LibraryContext.Domain.Model.Mangas;

namespace Inanna.LibraryContext.Application.Features.Mangas.Commands.Create;

public record AddVolumeCommand(Guid MangaId, string Title, string Number) : ICommand<VolumeId>;