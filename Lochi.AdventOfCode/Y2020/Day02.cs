using Lochi.AdventOfCode.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lochi.AdventOfCode.Y2020
{
    public class Day02 : ISolver
    {
        public Solution Solve(ReadOnlySpan<char> input)
        {
            //5-13 q: mzqtnknqzqgqhqdkwmlf 19-20 n: nnnnsnnnnnnnnnnnnnnn
            int valid = 0;
            foreach (ReadOnlySpan<char> line in input.SplitLines())
            {
                var index = line.IndexOf('-');
                int min = line[0] - '0';
                if (index == 2)
                {
                    min = min * 10 + (line[1] - '0');
                }
                int max = 0;
                char key = ' ';
                for (int i = index; i < line.Length; i++)
                {
                    char current = line[i];
                    if (current == ' ')
                    {
                        key = line[i + 1];
                        break;
                    }
                    else if (current != '-')
                    {
                        max = max * 10 + (current - '0');
                    }

                }
                int count = -1;
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] == key)
                    {
                        count++;
                    }
                }
                if (count <= max && count >= min)
                {
                    valid++;
                }
            }
            return new Solution(valid, 0);
        }
    }
}
