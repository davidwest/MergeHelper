using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq;

namespace MergeHelper.DemoConsole
{
    public static class DemoControlMergeParallel
    {
        public static void Start()
        {
            Debug.WriteLine("\n\n***** Demo ControlMergeParallel *****\n");

            const int max = 2000000;

            var intsDivisibleBy3 = Enumerable.Range(1, max).Where(x => x % 3 == 0);
            var intsDivisibleBy19 = Enumerable.Range(1, max).Where(x => x % 19 == 0);

            var adds = new ConcurrentBag<int>();
            var matches = new ConcurrentBag<int>();
            var removals = new ConcurrentBag<int>();

            var sw = Stopwatch.StartNew();

            new IntMerger()
                .FromSource(intsDivisibleBy19)
                .Add(toAdd => adds.Add(toAdd))
                .Update((s, d) => matches.Add(s))
                .Delete(toRemove => removals.Add(toRemove))
                .ExecuteParallel(intsDivisibleBy3);

            sw.Stop();

            var expectedAdds = Enumerable.Range(1, max).Where(x => x % 3 != 0 && x % 19 == 0).ToArray();
            var expectedMatches = Enumerable.Range(1, max).Where(x => x % 3 == 0 && x % 19 == 0).ToArray();
            var expectedRemovals = Enumerable.Range(1, max).Where(x => x % 3 == 0 && x % 19 != 0).ToArray();

            Debug.Assert(expectedAdds.SequenceEqual(adds.OrderBy(x => x)));
            Debug.Assert(expectedMatches.SequenceEqual(matches.OrderBy(x => x)));
            Debug.Assert(expectedRemovals.SequenceEqual(removals.OrderBy(x => x)));

            Debug.WriteLine($"Completed merge in {sw.Elapsed}: {adds.Count} adds; {matches.Count} matches; {removals.Count} removals");
        }
    }
}
