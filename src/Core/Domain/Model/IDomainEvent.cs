using MediatR;

namespace Inanna.Core.Domain.Model;

public interface IDomainEvent : INotification
{
    
    public DateTime OccuredOn { get; }
}