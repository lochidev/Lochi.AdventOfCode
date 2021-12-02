using Lochi.AdventOfCode.Helpers;

namespace Lochi.AdventOfCode.Y2021;

public class Day01 : ISolver
{
    public Solution Solve(ReadOnlySpan<char> input)
    {
        throw new NotImplementedException();
    }

    public Solution Solve(string input)
    {
        var depths = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToArray();
        var part1 = depths.Select((a, b) => b != 0 && a > depths[b - 1]).Count(b => b);
        var part2 = 0;
        var prevSum = 0;
        for (var i = 0; i < 2000; i++)
        {
            if (i + 3 > 2000) continue;
            var sum = depths[i] + depths[i + 1] + depths[i + 2];
            if (i != 0 && sum > prevSum) part2++;
            prevSum = sum;
        }

        return new Solution(part1, part2);
    }
}