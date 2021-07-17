using Lochi.AdventOfCode.Helpers;
using Lochi.AdventOfCode.Y2020;
using System;
using System.IO;

namespace Lochi.AdventOfCode
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ISolver solver = GetSolver(2020, 01);
            if (solver != null)
            {
                solver.Solve(GetInput());
            }
            Console.WriteLine("Solver not found");
            Console.ReadLine();
        }
        private static ISolver GetSolver(int year, int day)
        {
            switch (year)
            {
                case 2020:
                    switch (day)
                    {
                        case 01:
                            return new Day01();
                    }
                    break;
                default:
                    break;
            }
            return null;
        }
        private static ReadOnlySpan<char> GetInput()
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
