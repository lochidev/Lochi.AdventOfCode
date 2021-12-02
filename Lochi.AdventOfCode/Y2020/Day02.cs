using Lochi.AdventOfCode.Helpers;

namespace Lochi.AdventOfCode.Y2020;

public class Day02 : ISolver
{
    public Solution Solve(ReadOnlySpan<char> input)
    {
        //5-13 q: mzqtnknqzqgqhqdkwmlf 19-20 n: nnnnsnnnnnnnnnnnnnnn
        var valid = 0;
        var valid2 = 0;
        foreach (var line in input.SplitLines())
        {
            ReadOnlySpan<char> subStr = string.Empty;
            var index = line.IndexOf('-');
            var min = line[0] - '0';
            if (index == 2) min = min * 10 + (line[1] - '0');
            var max = 0;
            var key = ' ';
            for (var i = index; i < line.Length; i++)
            {
                var current = line[i];
                if (current == ' ')
                {
                    key = line[i + 1];
                    subStr = line[(i + 4)..];
                    break;
                }

                if (current != '-')
                {
                    max = max * 10 + (current - '0');
                }
            }

            var count = -1;
            for (var i = 0; i < line.Length; i++)
                if (line[i] == key)
                    count++;
            if (count <= max && count >= min) valid++;
            if (!subStr.IsEmpty)
            {
                var minFlag = subStr[min - 1] == key;
                if (max - 1 >= subStr.Length && minFlag)
                {
                    valid2++;
                }
                else
                {
                    var maxFlag = subStr[max - 1] == key;
                    if (maxFlag != minFlag && (maxFlag || minFlag)) valid2++;
                }
            }
        }

        return new Solution(valid, valid2);
    }

    public Solution Solve(string input)
    {
        throw new NotImplementedException();
    }
}