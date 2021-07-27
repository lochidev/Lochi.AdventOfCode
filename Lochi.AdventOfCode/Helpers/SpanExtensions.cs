using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lochi.AdventOfCode.Helpers
{
    public static class SpanExtensions
    {
        public static SpanSplitEnumerator<char> SplitLines(this ReadOnlySpan<char> str) => new(str, '\n');
    }
}
