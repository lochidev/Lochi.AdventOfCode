using Lochi.AdventOfCode.Helpers;

namespace Lochi.AdventOfCode.Y2020
{
    public class Day03 : ISolver
    {
        public Solution Solve(ReadOnlySpan<char> input)
        {
            int part1 = 0;
            int part2 = 0;
            int linePosition = 0;
            foreach (var line in input.SplitLines())
            {
                //...#.....#.......##......#.....
                //...#..................#........
                //....##....#.......#............
                //.........#.......#.......#.....
                //...#....##...#...#...#.#..#....
                int maxPosition = (line.Length - 1);
                if (linePosition > maxPosition)
                {
                    linePosition -= maxPosition + 1;
                }
                if (line[linePosition] == '#')
                {
                    part1++;
                }
                linePosition += 3;
            }
            return new Solution(part1, part2);
        }
    }
}
