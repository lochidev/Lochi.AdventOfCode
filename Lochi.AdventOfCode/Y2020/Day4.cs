using Lochi.AdventOfCode.Helpers;

namespace Lochi.AdventOfCode.Y2020;

internal class Day4 : ISolver
{
    public Solution Solve(ReadOnlySpan<char> input)
    {
        throw new NotImplementedException();
    }

    public Solution Solve(string input)
    {
        var part1 = 0;
        var part2 = 0;
        var passports = input.Split(
            new[] {"\n\n"},
            StringSplitOptions.None
        );
        foreach (var passport in passports)
        {
            //bool matches = new List<string>
            //{ "pid", "ecl", "hcl", "hgt", "eyr", "iyr", "byr"
            //}.All(x => passport.Contains(x));
            //if (matches)
            //{
            //    part1++;
            //}
            //ecl:gry pid:860033327 eyr:2020 hcl:#fffffd
            //byr:1937 iyr:2017 cid:147 hgt:183cm
            var byrIndex = passport.IndexOf("byr");
            var iyrIndex = passport.IndexOf("iyr");
            var eyrIndex = passport.IndexOf("eyr");
            var hgtIndex = passport.IndexOf("hgt");
            var hclIndex = passport.IndexOf("hcl");
            var eclIndex = passport.IndexOf("ecl");
            var pidIndex = passport.IndexOf("pid");
            var valid = true;
            var containsAll = true;
            if (byrIndex != -1)
            {
                var yearStr = passport.Substring(byrIndex + 4, 4);
                if (int.TryParse(yearStr, out var year))
                    valid = year is >= 1920 and <= 2002;
                else
                    valid = false;
            }
            else
            {
                containsAll = false;
                valid = false;
            }

            if (iyrIndex != -1)
            {
                if (valid)
                {
                    var yearStr = passport.Substring(iyrIndex + 4, 4);
                    if (int.TryParse(yearStr, out var year))
                        valid = year is >= 2010 and <= 2020;
                    else
                        valid = false;
                }
            }
            else
            {
                containsAll = false;
                valid = false;
            }

            if (eyrIndex != -1)
            {
                if (valid)
                {
                    var yearStr = passport.Substring(eyrIndex + 4, 4);
                    if (int.TryParse(yearStr, out var year))
                        valid = year is >= 2020 and <= 2030;
                    else
                        valid = false;
                }
            }
            else
            {
                containsAll = false;
                valid = false;
            }

            if (hgtIndex != -1)
            {
                //hgt:18367676cm
                if (valid)
                {
                    var start = hgtIndex + 4;
                    var count = 6;
                    if (start + count > passport.Length) count = passport.Length - start;
                    var subStr = passport.Substring(start, count);
                    var indexOfCm = subStr.IndexOf("cm");
                    var indexOfIn = subStr.IndexOf("in");
                    if (indexOfCm != -1)
                    {
                        if (int.TryParse(subStr.AsSpan(0, indexOfCm), out var height))
                            valid = height is >= 150 and <= 193;
                        else
                            valid = false;
                    }
                    else if (indexOfIn != -1)
                    {
                        if (int.TryParse(subStr.AsSpan(0, indexOfIn), out var height))
                            valid = height is >= 59 and <= 76;
                        else
                            valid = false;
                    }
                }
            }
            else
            {
                containsAll = false;
                valid = false;
            }

            if (hclIndex != -1)
            {
                //hcl:#cfa07d
                if (valid)
                {
                    var start = hclIndex + 4;
                    var count = 7;
                    if (start + count > passport.Length) count = passport.Length - start;
                    var subStr = passport.Substring(start, count);
                    if (subStr[0] == '#')
                    {
                        subStr = passport.Substring(start + 1, count - 1);
                        char[] validChars =
                            {'a', 'b', 'c', 'd', 'e', 'f', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};
                        valid = subStr.All(x => validChars.Contains(x));
                    }
                    else
                    {
                        valid = false;
                    }
                }
            }
            else
            {
                containsAll = false;
                valid = false;
            }

            if (eclIndex != -1)
            {
                //ecl:brn
                if (valid)
                {
                    var subStr = passport.Substring(eclIndex + 4, 3);
                    valid = new[] {"oth", "hzl", "grn", "gry", "brn", "blu", "amb"}.Contains(subStr);
                }
            }
            else
            {
                containsAll = false;
                valid = false;
            }

            if (pidIndex != -1)
            {
                //pid:166 559648
                if (valid)
                {
                    //cid:183
                    //byr:1928 pid:471385060
                    //hgt:192cm
                    //ecl:oth iyr:2010 hcl:#623a2f eyr:2020
                    var start = pidIndex + 4;
                    var count = 10;
                    if (start + count > passport.Length) count = passport.Length - start;
                    var subStr = passport.Substring(start, count);
                    char[] validChars = {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};
                    if (subStr.Length == 10 && subStr[9] is ' ' or '\n')
                    {
                        subStr = subStr.Substring(0, 9);
                        valid = subStr.All(x => validChars.Contains(x));
                    }
                    else
                    {
                        valid = subStr.All(x => validChars.Contains(x));
                    }
                }
            }
            else
            {
                containsAll = false;
                valid = false;
            }

            if (valid)
            {
                part1++;
                part2++;
            }
            else if (containsAll)
            {
                part1++;
            }
        }

        return new Solution(part1, part2);
    }
}