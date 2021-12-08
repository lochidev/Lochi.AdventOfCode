using System.Drawing;
using System.Runtime.CompilerServices;
using Lochi.AdventOfCode.Helpers;

namespace Lochi.AdventOfCode.Y2021;

public class Day5 : ISolver
{
    public Solution Solve(ReadOnlySpan<char> input)
    {
        throw new NotImplementedException();
    }

    public Solution Solve(string input)
    {
        var lines = input.Split(Environment.NewLine);
        Dictionary<Point, int> map = new();
        foreach (var line in lines)
        {
            var indexOfHyphon = line.IndexOf('-');
            var indexOfArrow = line.IndexOf('>');
            var (x1, y1) = ParsePoints(line[..indexOfHyphon].Split(','));
            var (x2, y2) = ParsePoints(line[(indexOfArrow + 1)..].Split(','));
            if (x1 == x2)
            {
                var bigger = y1 > y2 ? y1 : y2;
                var lesser = y1 < y2 ? y1 : y2;
                for (var i = lesser; i < bigger + 1; i++)
                {
                    var point = new Point(x1, i);
                    if (map.ContainsKey(point))
                        map[point]++;
                    else map.Add(point, 1);
                }
            }
            else if (y1 == y2)
            {
                var bigger = x1 > x2 ? x1 : x2;
                var lesser = x1 < x2 ? x1 : x2;
                for (var i = lesser; i < bigger + 1; i++)
                {
                    var point = new Point(i, y1);
                    if (map.ContainsKey(point))
                        map[point]++;
                    else map.Add(point, 1);
                }
            }
        }

        var part1 = map.Count(x => x.Value >= 2);
        //part2
        foreach (var line in lines)
        {
            var indexOfHyphen = line.IndexOf('-');
            var indexOfArrow = line.IndexOf('>');
            var (x1, y1) = ParsePoints(line[..indexOfHyphen].Split(','));
            var (x2, y2) = ParsePoints(line[(indexOfArrow + 1)..].Split(','));
            if (x1 == x2 || y1 == y2) continue;
            var ogX = x1;
            var ogY = y1;
            var biggerY = y1 > y2 ? y1 : y2;
            var lesserY = y1 < y2 ? y1 : y2;
            var lesserX = x1 < x2 ? x1 : x2;
            var diff = biggerY - lesserY;
            for (var i = 0; i < diff + 1; i++)
            {
                var point = new Point(x1, y1);
                if (map.ContainsKey(point))
                    map[point]++;
                else map.Add(point, 1);

                if (ogY == lesserY)
                    y1++;
                else
                    y1--;
                if (ogX == lesserX)
                    x1++;
                else
                    x1--;
            }
        }

        var part2 = map.Count(x => x.Value >= 2);
        return new Solution(part1, part2);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static (int p1, int p2) ParsePoints(IReadOnlyList<string> arr)
    {
        return (int.Parse(arr[0]), int.Parse(arr[1]));
    }
}