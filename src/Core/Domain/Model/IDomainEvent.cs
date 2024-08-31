using MediatR;

namespace Inanna.Core.Domain.Model;

public interface IDomainEvent : INotification
{
    public string AggregateSource { get; }
    
    public DateTime OccuredOn { get; }
}