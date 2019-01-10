using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MergeHelper.Test
{
    [TestClass]
    public class ControlMergeTests
    {
        [TestMethod]
        public void ControlMergeParallel_YieldsCorrectOutput()
        {
            const int max = 2000000;

            var intsDivisibleBy3 = Enumerable.Range(1, max).Where(x => x % 3 == 0);
            var intsDivisibleBy19 = Enumerable.Range(1, max).Where(x => x % 19 == 0);
            
            var adds = new ConcurrentBag<int>();
            var matches = new ConcurrentBag<int>();
            var removals = new ConcurrentBag<int>();

            new ControlMerger<int>()
                .FromSource(intsDivisibleBy19)
                .Add(adds.Add)
                .Update((s, d) => matches.Add(s))
                .Delete(removals.Add)
                .ExecuteParallel(intsDivisibleBy3);

            var expectedAdds = Enumerable.Range(1, max).Where(x => x % 3 != 0 && x % 19 == 0).ToArray();
            var expectedMatches = Enumerable.Range(1, max).Where(x => x % 3 == 0 && x % 19 == 0).ToArray();
            var expectedRemovals = Enumerable.Range(1, max).Where(x => x % 3 == 0 && x % 19 != 0).ToArray();

            CollectionAssert.AreEquivalent(matches, expectedMatches);
            CollectionAssert.AreEquivalent(adds, expectedAdds);
            CollectionAssert.AreEquivalent(removals, expectedRemovals);
        }

        [TestMethod]
        [ExpectedException(typeof(AggregateException))]
        public void ControlMergeParallel_WithSourceDuplicateNonDefaultKeys_ThrowsException()
        {
            var source = new[] { 1, 1, 2, 3, 8, 9, 10 };
            var dest = new List<int> { 1, 3, 5, 7, 9 };

            var adds = new ConcurrentBag<int>();
            var matches = new ConcurrentBag<int>();
            var removals = new ConcurrentBag<int>();

            source
                .ControlMergeParallel(
                    dest,
                    x => x,
                    toAdd => adds.Add(toAdd),
                    (s, d) => matches.Add(s),
                    toRemove => removals.Add(toRemove));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ControlMergeParallel_WithDestDuplicateNonDefaultKeys_ThrowsException()
        {
            var source = new[] { 1, 2, 3, 8, 9, 10 };
            var dest = new List<int> { 1, 1, 3, 5, 7, 9 };

            var adds = new ConcurrentBag<int>();
            var matches = new ConcurrentBag<int>();
            var removals = new ConcurrentBag<int>();

            source
                .ControlMergeParallel(
                    dest,
                    x => x,
                    toAdd => adds.Add(toAdd),
                    (s, d) => matches.Add(s),
                    toRemove => removals.Add(toRemove));
        }
    }
}
