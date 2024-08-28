namespace Inanna.Core.Domain.Model;

public abstract record DomainEvent : ValueObject, IDomainEvent
{
    protected DomainEvent(string aggregateSource, DateTime occuredOn)
    {
        AggregateSource = aggregateSource;
        OccuredOn = occuredOn;
    }

    protected DomainEvent(string aggregateSource) : this(aggregateSource, DateTime.UtcNow)
    { }
    
    public string AggregateSource { get; }
    
    public DateTime OccuredOn { get; }
}