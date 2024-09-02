namespace Inanna.Core.Domain.Model;

public abstract record Identity<T> : ValueObject, IIdentity
{
    private readonly T _value;

    protected Identity(T value)
    {
        Value = value;
    }

    public T Value
    {
        get => _value;
        private init
        {
            Validate(value);
            
            _value = value;
        }
    }

    protected virtual void Validate(T value)
    { }
}