using Lochi.AdventOfCode.Helpers;

namespace Lochi.AdventOfCode.Y2021;

public class Day7 : ISolver
{
    public Solution Solve(ReadOnlySpan<char> input)
    {
        throw new NotImplementedException();
    }

    public Solution Solve(string input)
    {
        var positions = input.Split(',').Select(int.Parse).ToArray();
        var leastSum = 0;
        for (var i = 0; i < positions.Length; i++)
        {
            var sum = positions.Sum(position => Math.Abs(positions[i] - position));
            if (leastSum != 0 && sum >= leastSum) continue;
            leastSum = sum;
        }

        var part1 = leastSum;
        //part2
        leastSum = 0;
        for (var i = 0; i < positions.Length; i++)
        {
            var sum = positions.Sum(position => CalculateSum(Math.Abs(positions[i] - position)));
            if (leastSum != 0 && sum >= leastSum) continue;
            leastSum = sum;
        }

        return new Solution(part1, leastSum);
    }

    private static int CalculateSum(int diff)
    {
        var sum = 0;
        for (var i = 1; i < diff + 1; i++) sum += i;
        return sum;
    }
}