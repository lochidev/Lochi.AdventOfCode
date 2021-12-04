using BenchmarkDotNet.Attributes;
using Lochi.AdventOfCode.Helpers;
using static Lochi.AdventOfCode.Helpers.Common;

namespace Lochi.AdventOfCode.Benchmark;

public class Benchy
{
    private string Input;

    [GlobalSetup]
    public void GlobalSetup()
    {
        Input = GetInput(AppState.Year, AppState.Day);
    }

    [Benchmark]
    public Solution Solve()
    {
        return GetSolver(AppState.Year, AppState.Day).Solve((ReadOnlySpan<char>) Input);
    }
}