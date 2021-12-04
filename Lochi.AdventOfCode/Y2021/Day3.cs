using Lochi.AdventOfCode.Helpers;

namespace Lochi.AdventOfCode.Y2021;

public class Day3 : ISolver
{
    public Solution Solve(ReadOnlySpan<char> input)
    {
        throw new NotImplementedException();
    }

    public Solution Solve(string input)
    {
        //part1
        var gamma = string.Empty;
        var epsilon = string.Empty;
        var lines = input.Split(Environment.NewLine).ToList();
        for (var i = 0; i < 12; i++)
        {
            var onCount = lines.Select(x => x[i] == '1').Count(b => b);
            var offCount = lines.Select(x => x[i] == '0').Count(b => b);
            if (onCount > offCount)
            {
                gamma += "1";
                epsilon += "0";
            }
            else
            {
                gamma += "0";
                epsilon += "1";
            }
        }

        var gammaDec = Convert.ToInt32(gamma, 2);
        var epsilonDec = Convert.ToInt32(epsilon, 2);
        //part2
        var oxList = new List<string>();
        var coList = new List<string>();
        for (var i = 0; i < 12; i++)
            //TODO: Move both oxList and coList so enumerations don't happen twice

            if (i == 0)
            {
                Filter(ref lines, ref oxList, i);
                Filter(ref lines, ref coList, i, false);
            }
            else
            {
                if (oxList.Count > 1) Filter(ref oxList, ref oxList, i);

                if (coList.Count > 1) Filter(ref coList, ref coList, i, false);
            }

        var ox = Convert.ToInt32(oxList.First(), 2);
        var co = Convert.ToInt32(coList.First(), 2);
        return new Solution(gammaDec * epsilonDec, ox * co);
    }

    private static void Filter(ref List<string> input, ref List<string> output, int position, bool oxygen = true)
    {
        var onSelection = input.Where(x => x[position] == '1').ToList();
        var offSelection = input.Where(x => x[position] == '0').ToList();
        if (onSelection.Count >= offSelection.Count)
            output = oxygen ? onSelection : offSelection;
        else
            output = oxygen ? offSelection : onSelection;
    }
}