using Lochi.AdventOfCode.Helpers;

namespace Lochi.AdventOfCode.Y2020
{
    public class Day01 : ISolver
    {
        public Solution Solve(ReadOnlySpan<char> input)
        {
            int length = 0;
            byte[] numberFlags = new byte[2048];
            int[] numbers = new int[512];
            foreach (ReadOnlySpan<char> line in input.SplitLines())
            {
                int num = line[0] - '0';
                for (int i = 1; i < line.Length; i++)
                {
                    num = num * 10 + (line[i] - '0');
                }
                numbers[length++] = num;
                numberFlags[num] = 1;
            }
            Array.Sort(numbers, 0, length);
            int part1 = -1;
            int part2 = -1;
            for (int i = 0; i < length; i++)
            {
                int a = numbers[i];
                int tmp = 2020 - a;
                if (part1 == -1 && numberFlags[tmp] == 1)
                {
                    part1 = tmp * a;
                    if (part2 > 0)
                    {
                        return new Solution(part1, part2);
                    }
                }

                for (int j = i + 1; j < length; j++)
                {
                    int b = numbers[j];
                    if (b < tmp)
                    {
                        int c = tmp - b;
                        if (numberFlags[c] == 1)
                        {
                            part2 = c * a * b;
                            if (part1 > 0)
                            {
                                return new Solution(part1, part2);
                            }

                            break;
                        }

                    }
                }

            }
            return new Solution(part1, part2);
        }
    }
}
