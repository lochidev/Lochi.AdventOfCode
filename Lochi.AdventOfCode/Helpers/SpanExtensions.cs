namespace Lochi.AdventOfCode.Helpers
{
    public static class SpanExtensions
    {
        public static SpanSplitEnumerator<char> SplitLines(this ReadOnlySpan<char> str)
        {
            return new(str, '\n');
        }
    }
}
