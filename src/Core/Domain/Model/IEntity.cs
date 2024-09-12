﻿using MediatR;

namespace Inanna.Core.Domain.Model;

public interface IEntity<out TIdentity> where TIdentity : AbstractIdentity
{
    public TIdentity Identity { get; }
}