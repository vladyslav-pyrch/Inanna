﻿using MediatR;

namespace Inanna.Core.Domain.Model;

public interface IAggregateRoot<TIdentity> : IEntity<TIdentity> where TIdentity : AbstractIdentity
{
    public void PublishDomainEvents(IPublisher publisher);
    
    public void Evolve(IEnumerable<IDomainEvent<TIdentity>> domainEvents);
}