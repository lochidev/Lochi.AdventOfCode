using Lochi.AdventOfCode.Helpers;

namespace Lochi.AdventOfCode.Y2021;

public class Day6 : ISolver
{
    public Solution Solve(ReadOnlySpan<char> input)
    {
        throw new NotImplementedException();
    }

    public Solution Solve(string input)
    {
        var inputArr = input.Split(',').Select(s => Convert.ToByte(s));
        var lanterFish = inputArr.ToList();
        for (var i = 0; i < 80; i++)
        {
            var count = lanterFish.Count;
            for (var j = 0; j < count; j++)
            {
                var fish = lanterFish[j];
                if (fish == 0)
                {
                    lanterFish.Add(8);
                    lanterFish[j] = 6;
                }
                else
                {
                    lanterFish[j]--;
                }
            }
        }

        //part2
        var fishDic = new Dictionary<int, long>();
        for (var i = -1; i < 9; i++) fishDic[i] = 0;
        foreach (var fish in inputArr) fishDic[fish]++;
        for (var i = 0; i < 256; i++)
        {
            for (byte k = 0; k < 9; k++) fishDic[k - 1] = fishDic[k];
            fishDic[8] = fishDic[-1];
            fishDic[6] += fishDic[-1];
        }

        return new Solution(lanterFish.Count, fishDic.Skip(1).Sum(x => x.Value));
    }
}