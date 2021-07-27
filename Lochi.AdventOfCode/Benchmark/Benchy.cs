﻿using BenchmarkDotNet.Attributes;
using Lochi.AdventOfCode.Helpers;
using static Lochi.AdventOfCode.Common;
namespace Lochi.AdventOfCode.Benchmark
{
    public class Benchy
    {
        private string Input;
        [GlobalSetup]
        public void GlobalSetup()
        {
            Input = GetInput();
        }
        [Benchmark]
        public Solution Solve()
        {
            return GetSolver(AppState.Year, AppState.Day).Solve(Input);
        }
    }
}
