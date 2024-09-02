using Inanna.Core.Domain.Model;

namespace Inanna.LibraryContext.Domain.Model.Shared;

public abstract record IntegerIdentity(int Value) : Identity<int>(Value)
{
    protected override void Validate(int value)
    {
        if (int.IsNegative(value))
            throw new ArgumentException("Identity value cannot be null");
    }
}