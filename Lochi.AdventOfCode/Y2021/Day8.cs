using Lochi.AdventOfCode.Helpers;

namespace Lochi.AdventOfCode.Y2021;

public class Day8 : ISolver
{
    public Solution Solve(ReadOnlySpan<char> input)
    {
        throw new NotImplementedException();
    }

    public Solution Solve(string input)
    {
        var lines = input.Split(Environment.NewLine);
        int[] lengths = {2, 4, 3, 7};
        var part1 = (from line in lines
            let delimIndex = line.IndexOf('|')
            select line[(delimIndex + 2)..].Split(' ')
            into output
            select output.Select(x => lengths.Contains(x.Length)).Count(b => b)).Sum();
        var part2 = 0;
        foreach (var line in lines)
        {
            var delimIndex = line.IndexOf('|');
            var signalPattern = ParseSignalPattern(line[..delimIndex].Split(' '));
            var output = line[(delimIndex + 2)..].Split(' ');
            var num = 0;
            foreach (var val in output)
            {
                var x = val.Length switch
                {
                    2 => 1,
                    3 => 7,
                    4 => 4,
                    7 => 8,
                    _ => 0
                };
                if (x == 0) x = signalPattern.First(p => p.Key != 8 && val.All(p.Value.Contains)).Key;
                num = num * 10 + x;
            }

            part2 += num;
        }

        return new Solution(part1, part2);
    }

    private static Dictionary<int, string> ParseSignalPattern(string[] input)
    {
        var dict = new Dictionary<int, string>();
        foreach (var val in input)
        {
            var num = val.Length switch
            {
                2 => 1,
                3 => 7,
                4 => 4,
                7 => 8,
                _ => 0
            };
            if (num != 0)
                dict.Add(num, val);
        }

        var fives = input.Where(s => s.Length == 5).ToArray();
        IEnumerable<char> rows = fives[0];
        for (var i = 1; i < fives.Length; i++) rows = fives[i].Intersect(rows);

        var cols = new HashSet<char>();
        var colsForThree = (from val in fives 
            from t in val where !rows.Contains(t) where !cols.Add(t) select t).ToList();

        var fifthCol = dict[4].First(c => !colsForThree.Contains(c) && !rows.Contains(c));
        var thirdVal = fives.First(s => colsForThree.All(s.Contains));
        var fifthVal = fives.First(s => s.Contains(fifthCol) && s != thirdVal);
        var secondVal = fives.First(s => s != thirdVal && s != fifthVal);
        var twoCol = secondVal.First(c => colsForThree.Contains(c) && !rows.Contains(c));
        dict.Add(3, thirdVal);
        dict.Add(2, secondVal);
        dict.Add(5, fifthVal);
        var sixes = input.Where(s => s.Length == 6).ToArray();
        var zeroVal = sixes.First(s => cols.All(s.Contains));
        var ninthVal = sixes.First(s => s.Contains(twoCol) && s != zeroVal);
        var sixthVal = sixes.First(s => s != zeroVal && s != ninthVal);
        dict.Add(0, zeroVal);
        dict.Add(9, ninthVal);
        dict.Add(6, sixthVal);
        return dict;
    }
}