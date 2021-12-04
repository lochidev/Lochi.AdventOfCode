using Lochi.AdventOfCode.Helpers;

namespace Lochi.AdventOfCode.Y2020;

public class Day3 : ISolver
{
    public Solution Solve(ReadOnlySpan<char> input)
    {
        var part1 = 0;
        var r1d1 = 0;
        var r1d2 = 0;
        var r5d1 = 0;
        var r7d1 = 0;
        var r1d1Position = 0;
        var r1d2Position = 1;
        var r3d1Position = 0;
        var r5d1Position = 0;
        var r7d1Position = 0;
        var skipped = false;
        var start = true;
        foreach (var line in input.SplitLines())
        {
            //...#.....#.......##......#.....
            //...#..................#........
            //....##....#.......#............
            //.........#.......#.......#.....
            //..#..............#.........#..#
            //.....#.........#....#....#....#
            //....##..........#.#.##.........
            var maxPosition = line.Length - 1;
            if (!start)
            {
                //when 1 right 1 down
                if (r1d1Position > maxPosition) r1d1Position -= maxPosition + 1;
                if (line[r1d1Position] == '#') r1d1++;
                //when 1 right 2 down
                if (skipped)
                {
                    if (r1d2Position > maxPosition) r1d2Position -= maxPosition + 1;
                    if (line[r1d2Position] == '#') r1d2++;
                    r1d2Position++;
                }

                skipped = !skipped;
                //when 5 right 1 down
                if (r5d1Position > maxPosition) r5d1Position -= maxPosition + 1;
                if (line[r5d1Position] == '#') r5d1++;
                //when 7 right 1 down
                if (r7d1Position > maxPosition) r7d1Position -= maxPosition + 1;
                if (line[r7d1Position] == '#') r7d1++;
                if (r3d1Position > maxPosition) r3d1Position -= maxPosition + 1;
                if (line[r3d1Position] == '#') part1++;
            }

            r3d1Position += 3;
            r1d1Position++;
            r5d1Position += 5;
            r7d1Position += 7;
            start = false;
        }

        return new Solution(part1.ToString(), (r1d1 * r1d2 * r5d1 * r7d1 * part1).ToString());
    }

    public Solution Solve(string input)
    {
        throw new NotImplementedException();
    }
}