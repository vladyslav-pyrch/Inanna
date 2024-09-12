namespace Inanna.Core.Domain.Model;

public abstract record DomainEvent<TIdentity> : ValueObject, IDomainEvent<TIdentity>
    where TIdentity : AbstractIdentity
{
    TIdentity IDomainEvent<TIdentity>.AggregateRootId { get; set; }
    
    DateTime IDomainEvent<TIdentity>.OccuredOn { get; set; }


    public TIdentity AggregateRootId
    {
        get => ((IDomainEvent<TIdentity>)this).AggregateRootId;
        init => ((IDomainEvent<TIdentity>)this).AggregateRootId = value;
    }

    public DateTime OccuredOn
    {
        get => ((IDomainEvent<TIdentity>)this).OccuredOn; 
        init => ((IDomainEvent<TIdentity>)this).OccuredOn = value;
    }
    
}