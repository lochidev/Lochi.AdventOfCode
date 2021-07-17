using System;

namespace Lochi.AdventOfCode.Helpers
{
    public interface ISolver
    {
        Solution Solve(ReadOnlySpan<char> input);
    }
}
