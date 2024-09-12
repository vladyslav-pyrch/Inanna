using Inanna.Core.Domain.Model;

namespace Inanna.LibraryContext.Domain.Model.Shared;

public abstract record GuidAbstractIdentity(Guid Value) : AbstractIdentity<Guid>(Value);