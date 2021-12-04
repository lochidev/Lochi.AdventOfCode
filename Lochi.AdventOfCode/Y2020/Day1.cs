using Lochi.AdventOfCode.Helpers;

namespace Lochi.AdventOfCode.Y2020;

public class Day1 : ISolver
{
    public Solution Solve(ReadOnlySpan<char> input)
    {
        var length = 0;
        var numberFlags = new byte[2048];
        var numbers = new int[512];
        foreach (var line in input.SplitLines())
        {
            var num = line[0] - '0';
            for (var i = 1; i < line.Length; i++) num = num * 10 + (line[i] - '0');
            numbers[length++] = num;
            numberFlags[num] = 1;
        }

        Array.Sort(numbers, 0, length);
        var part1 = -1;
        var part2 = -1;
        for (var i = 0; i < length; i++)
        {
            var a = numbers[i];
            var tmp = 2020 - a;
            if (part1 == -1 && numberFlags[tmp] == 1)
            {
                part1 = tmp * a;
                if (part2 > 0) return new Solution(part1, part2);
            }

            for (var j = i + 1; j < length; j++)
            {
                var b = numbers[j];
                if (b < tmp)
                {
                    var c = tmp - b;
                    if (numberFlags[c] == 1)
                    {
                        part2 = c * a * b;
                        if (part1 > 0) return new Solution(part1, part2);

                        break;
                    }
                }
            }
        }

        return new Solution(part1, part2);
    }

    public Solution Solve(string input)
    {
        throw new NotImplementedException();
    }
}