using Lochi.AdventOfCode.Helpers;

namespace Lochi.AdventOfCode.Y2020
{
    internal class Day04 : ISolver
    {
        public Solution Solve(ReadOnlySpan<char> input)
        {
            throw new NotImplementedException();
        }

        public Solution Solve(string input)
        {
            int part1 = 0;
            int part2 = 0;
            string[] passports = input.Split(
                new[] { "\n\n" },
                StringSplitOptions.None
                );
            foreach (string passport in passports)
            {
                bool matches = new List<string>
                { "pid", "ecl", "hcl", "hgt", "eyr", "iyr", "byr"
                }.All(x => passport.Contains(x));
                if (matches)
                {
                    part1++;
                }
            }
            return new Solution(part1, part2);
        }
    }
}
