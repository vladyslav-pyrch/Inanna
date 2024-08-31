namespace Inanna.Core.Domain.Model;

public abstract record DomainEvent(DateTime OccuredOn) : ValueObject, IDomainEvent
{
    protected DomainEvent() : this(DateTime.UtcNow)
    { }
}