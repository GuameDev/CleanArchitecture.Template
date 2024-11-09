public abstract class ValueObject : IEquatable<ValueObject>
{
    public static bool operator ==(ValueObject? a, ValueObject? b)
    {
        if (a is null && b is null)
        {
            return true;
        }

        if (a is null || b is null)
        {
            return false;
        }

        return a.Equals(b);
    }

    public static bool operator !=(ValueObject? a, ValueObject? b) => !(a == b);

    public bool Equals(ValueObject? other)
    {
        if (other is null || GetType() != other.GetType())
            return false;

        return GetAtomicValues().SequenceEqual(other.GetAtomicValues());
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        return Equals(obj as ValueObject);
    }

    public override int GetHashCode()
    {
        HashCode hashCode = default;

        foreach (object obj in GetAtomicValues())
        {
            hashCode.Add(obj);
        }

        return hashCode.ToHashCode();
    }

    protected abstract IEnumerable<object> GetAtomicValues();
}
