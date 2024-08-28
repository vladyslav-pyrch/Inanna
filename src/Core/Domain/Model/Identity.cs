namespace Inanna.Core.Domain.Model;

public abstract record Identity<T> : ValueObject, IIdentity
{
    protected Identity(T value)
    {
        Value = value;
    }
    
    public T Value { get; init; }
}