using BenchmarkDotNet.Running;
using Lochi.AdventOfCode.Benchmark;
using Lochi.AdventOfCode.Helpers;
using static Lochi.AdventOfCode.Helpers.Common;

var solver = GetSolver(AppState.Year, AppState.Day);
if (solver != null)
{
    var input = GetInput(AppState.Year, AppState.Day);
    Solution solution;
    if (AppState.Performant)
        solution = solver.Solve((ReadOnlySpan<char>) input);
    else 
        solution = solver.Solve(input);

    Console.WriteLine($"Part 1: {solution.Part1}\nPart 2: {solution.Part2}\nPress a key to run benchmark");
    Console.ReadLine();
    BenchmarkRunner.Run<Benchy>();
}
else
{
    Console.WriteLine("Solver not found");
}

Console.ReadLine();