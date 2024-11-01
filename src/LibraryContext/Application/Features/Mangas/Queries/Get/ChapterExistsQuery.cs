﻿using Inanna.Core.Messaging;

namespace Inanna.LibraryContext.Application.Features.Mangas.Queries.Get;

public record ChapterExistsQuery(Guid ChapterId) : IQuery<bool>;