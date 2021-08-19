namespace Lochi.AdventOfCode.Helpers
{
    public interface ISolver
    {
        Solution Solve(ReadOnlySpan<char> input);
        Solution Solve(string input);
    }
}
