using BenchmarkDotNet.Attributes;
using Lochi.AdventOfCode.Helpers;
using static Lochi.AdventOfCode.Common;
namespace Lochi.AdventOfCode.Benchmark
{
    public class Benchy
    {
        private readonly ISolver _solver = GetSolver(AppState.Year, AppState.Day);
        private readonly string _input = GetInput();

        [Benchmark]
        public Solution Solve()
        {
            return _solver.Solve(_input);
        }
    }
}
