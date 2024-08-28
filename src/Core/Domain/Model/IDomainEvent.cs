namespace Inanna.Core.Domain.Model;

public interface IDomainEvent
{
    public string AggregateSource { get; }
    
    public DateTime OccuredOn { get; }
}