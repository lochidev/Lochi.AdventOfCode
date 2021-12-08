namespace Lochi.AdventOfCode.Helpers;

public readonly struct Solution
{
    public Solution(int part1, int part2) : this(part1.ToString(), part2.ToString())
    {
    }

    public Solution(long part1, long part2) : this(part1.ToString(), part2.ToString())
    {
    }

    public Solution(int part1, long part2) : this(part1.ToString(), part2.ToString())
    {
    }

    public Solution(long part1, int part2) : this(part1.ToString(), part2.ToString())
    {
    }

    public Solution(string part1, string part2)
    {
        Part1 = part1;
        Part2 = part2;
    }

    public string Part1 { get; }

    public string Part2 { get; }
}