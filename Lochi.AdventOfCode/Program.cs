using BenchmarkDotNet.Running;
using Lochi.AdventOfCode.Benchmark;
using Lochi.AdventOfCode.Helpers;
using static Lochi.AdventOfCode.Common;

namespace Lochi.AdventOfCode
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ISolver solver = GetSolver(AppState.Year, AppState.Day);
            if (solver != null)
            {
                string input = GetInput(AppState.Year, AppState.Day);
                Solution solution = new();
                if (AppState.Performant)
                {
                    solution = solver.Solve((ReadOnlySpan<char>)input);
                }
                else
                {
                    solution = solver.Solve(input);
                }
                Console.WriteLine($"Part 1: {solution.Part1}\nPart 2: {solution.Part2}\nPress a key to run benchmark");
                Console.ReadLine();
                BenchmarkRunner.Run<Benchy>();
            }
            else
            {
                Console.WriteLine("Solver not found");
            }
            Console.ReadLine();
        }

    }
}
