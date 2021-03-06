namespace Lochi.AdventOfCode.Helpers;

public ref struct SpanSplitEnumerator<T> where T : IEquatable<T>
{
    private readonly T _seperator;

    private ReadOnlySpan<T> _str;
    public ReadOnlySpan<T> Current { get; private set; }

    public SpanSplitEnumerator(ReadOnlySpan<T> str, T seperator) : this()
    {
        _seperator = seperator;
        _str = str;
        Current = default;
    }

    public SpanSplitEnumerator<T> GetEnumerator()
    {
        return this;
    }

    public bool MoveNext()
    {
        if (_str.IsEmpty) return false;
        var span = _str;
        var index = _str.IndexOf(_seperator);
        if (index == -1)
        {
            _str = ReadOnlySpan<T>.Empty;
            Current = span;
        }
        else
        {
            _str = span.Slice(index + 1);
            Current = span.Slice(0, index);
        }

        return true;
    }
}