using Lochi.AdventOfCode.Helpers;
using Lochi.AdventOfCode.Y2020;
using System;
using System.IO;

namespace Lochi.AdventOfCode
{
    public static class Common
    {
        public static ISolver GetSolver(int year, int day)
        {
            switch (year)
            {
                case 2020:
                    switch (day)
                    {
                        case 01:
                            return new Day01();
                        case 02:
                            return new Day02();
                        case 03:
                            return new Day03();
                    }
                    break;
                default:
                    break;
            }
            return null;
        }
        public static string GetInput()
        {
            string text = File.ReadAllText("input.txt");
            if (text == null)
            {
                throw new Exception("Input not found");
            }
            return text;
        }
    }
}
