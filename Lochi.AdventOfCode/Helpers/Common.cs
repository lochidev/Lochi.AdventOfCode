using Lochi.AdventOfCode.Helpers;
using Lochi.AdventOfCode.Y2020;

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
                        case 04:
                            return new Day04();
                    }
                    break;
                default:
                    break;
            }
            return null;
        }
        public static string GetInput(int year, int day)
        {
            string filename = $"Inputs\\{year}\\day{day}.txt";
            return File.ReadAllText(filename);
        }
    }
}
