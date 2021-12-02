using Lochi.AdventOfCode.Helpers;

namespace Lochi.AdventOfCode.Y2021;

public class Day02 : ISolver
{
    public Solution Solve(ReadOnlySpan<char> input)
    {
        throw new NotImplementedException();
    }

    public Solution Solve(string input)
    {
        int horizontal = 0;
        int depth = 0;
        int depth2 = 0;
        int aim = 0;
        var lines = input.Split(Environment.NewLine);
        foreach (var line in lines)
        {
            switch (line)
            {
                case { } a when a.Contains("f"):
                    var num = a[^1] - '0';
                    horizontal += num;
                    depth2 += aim * num;  
                    break;
                case { } b when b.Contains("u"):
                    num = b[^1] - '0';
                    depth -= num;
                    aim -= num;
                    break;
                case { } c when c.Contains("d"):
                    num = c[^1] - '0';
                    depth += num;
                    aim += num;
                    break;
            }
        }

        return new Solution(horizontal * depth, horizontal * depth2);
    }
}