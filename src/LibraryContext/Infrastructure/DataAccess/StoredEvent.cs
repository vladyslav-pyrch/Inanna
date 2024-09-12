using Inanna.Core.Domain.Model;

namespace Inanna.LibraryContext.Infrastructure.DataAccess;

internal class StoredEvent
{
    public Guid Id { get; set; }
    
    public DateTime OccuredOn { get; set; }
    
    public int Position { get; set; }
    
    public AbstractIdentity AggregateRootId { get; set; }
    
    public IDomainEvent Event { get; set; }
}