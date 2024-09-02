using Inanna.Core.Domain.Model;

namespace Inanna.LibraryContext.Domain.Model.Shared;

public abstract record IntegerIdentity(int Value) : Identity<int>(Value)
{
    protected override void Validate(int value)
    {
        BusynessRuleException.ThrowIf(() => int.IsNegative(value), "Integer identity value cannot be negative.");
    }
}