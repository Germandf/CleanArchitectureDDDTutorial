using CleanArchitectureDDDTutorial.Domain.Common.Models;

namespace CleanArchitectureDDDTutorial.Domain.Common.ValueObjects;

public sealed class Rating : ValueObject
{
    public float Value { get; set; }

    private Rating(float value)
    {
        Value = value;
    }

    public static Rating CreateNew(float value)
    {
        return new Rating(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
