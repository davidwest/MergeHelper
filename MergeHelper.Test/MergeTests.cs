using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MergeHelper.Test
{
    [TestClass]
    public class MergeTests
    {
        [TestMethod]
        public void Merge_OfSameType_YieldsCorrectResult()
        {
            var source = new[] { 1, 2, 3, 8, 9, 10 };
            var dest = new [] { 1, 3, 5, 7, 9 };

            var result = source.Merge(dest, x => x).ToArray();
            
            CollectionAssert.AreEquivalent(result, source);
        }
        
        [TestMethod]
        public void Merge_OfSameType_HandlesUnconditionalEventsCorrectly()
        {
            var source = new[] { 1, 2, 3, 8, 9, 10 };
            var dest = new [] { 1, 3, 5, 7, 9 };

            var matches = new List<int>();
            var adds = new List<int>();
            var removals = new List<int>();

            var result = 
                source.Merge(dest, 
                   x => x,
                   (s,d) => d,
                   toAdd => adds.Add(toAdd),
                   (s, d) => matches.Add(s),
                   toRemove => removals.Add(toRemove)).ToArray();

            CollectionAssert.AreEquivalent(result, source);
            CollectionAssert.AreEquivalent(adds, new []{2, 8, 10});
            CollectionAssert.AreEquivalent(removals, new []{5, 7});
            CollectionAssert.AreEquivalent(matches, new[] { 1, 3, 9 });
        }
        
        [TestMethod]
        public void Merge_OfSameType_HandlesConditionalEventsCorrectly()
        {
            var source = new [] { 1, 2, 3, 8, 9, 10 };
            var dest = new [] { 1, 3, 5, 7, 9 };
            
            var result = 
                source.Merge(dest,
                    x => x,
                    toAdd => toAdd != 10,
                    toRemove => toRemove != 7).ToArray();

            CollectionAssert.AreEquivalent(result, new []{1, 2, 3, 7, 8, 9});
        }
        
        [TestMethod]
        public void MergeAdd_OfSameType_YieldsCorrectResult()
        {
            var source = new [] { 1, 2, 3, 8, 9, 10 };
            var dest = new [] { 1, 3, 5, 7, 9 };
            
            var result = source.MergeAdd(dest, x => x).ToArray();

            CollectionAssert.AreEquivalent(result, new []{1, 2, 3, 5, 7, 8, 9, 10});
        }
        
        [TestMethod]
        public void MergeAddOrUpdate_OfSameType_HandlesUnconditionalEventsCorrectly()
        {
            var source = new[] { 1, 2, 3, 8, 9, 10 };
            var dest = new [] { 1, 3, 5, 7, 9 };
            
            var matches = new List<int>();
            var adds = new List<int>();

            var result = source.MergeAddOrUpdate(
                    dest,
                    x => x,
                    (s,d) => d,
                    toAdd => adds.Add(toAdd), 
                    (s, d) => matches.Add(s)).ToArray();

            CollectionAssert.AreEquivalent(result, new[] { 1, 2, 3, 5, 7, 8, 9, 10 });
            CollectionAssert.AreEquivalent(adds, new[] { 2, 8, 10 });
            CollectionAssert.AreEquivalent(matches, new[] { 1, 3, 9 });
        }
        
        [TestMethod]
        public void MergeAdd_OfSameType_HandlesConditionalEventsCorrectly()
        {
            var source = new [] { 1, 2, 3, 8, 9, 10 };
            var dest = new [] { 1, 3, 5, 7, 9 };
            
            var result = source.MergeAdd(dest, x => x, toAdd => toAdd != 10).ToArray();

            CollectionAssert.AreEquivalent(result, new[] { 1, 2, 3, 5, 7, 8, 9 });
        }

        [TestMethod]
        public void Merge_OfSameType_HandlesMappingCorrectly()
        {
            var source = new [] { 1, 2, 3, 8, 9, 10 };
            var dest = new [] { 1, 3, 5, 7, 9 };

            var result = source.Merge(dest, x => x, x => -x, (s,d) => d * 10).ToArray();

            CollectionAssert.AreEquivalent(result, new []{10, -2, 30, -8, 90, -10});
        }
        
        [TestMethod]
        public void MergeAdd_OfSameType_HandlesMappingCorrectly()
        {
            var source = new [] { 1, 2, 3, 8, 9, 10 };
            var dest = new [] { 1, 3, 5, 7, 9 };

            var result = source.MergeAdd(dest, x => x, x => -x).ToArray();
            
            CollectionAssert.AreEquivalent(result, new[] { 1, -2, 3, 5, 7, -8, 9, -10 });
        }
        
        [TestMethod]
        public void Merge_OfSameType_WithDefaultKeys_YieldsCorrectResult()
        {
            var source = new [] { 0, 0, 0, 1, 2, 3, 8, 9, 10 };
            var dest = new [] { 0, 0, 0, 1, 3, 5, 7, 9 };

            var result = source.Merge(dest, x => x).ToArray();
            
            CollectionAssert.AreEquivalent(result, new []{0, 0, 0, 0, 0, 0, 1, 2, 3, 8, 9, 10});
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Merge_OfSameType_WithSourceDuplicateNonDefaultKeys_ThrowsException()
        {
            var source = new[] { 1, 1, 2, 3, 8, 9, 10 };
            var dest = new List<int> { 1, 3, 5, 7, 9 };
            
            var result = source.Merge(dest, x => x).ToArray();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MergeInto_OfSameType_WithDestDuplicateNonDefaultKeys_ThrowsException()
        {
            var source = new[] { 1, 2, 3, 8, 9, 10 };
            var dest = new List<int> { 1, 1, 3, 5, 7, 9 };

            var result = source.Merge(dest, x => x).ToArray();
        }
        
        [TestMethod]
        public void Merge_OfDifferentTypes_YieldsCorrectResult()
        {
            var source = new [] { 1, 2, 3, 8, 9, 10 };
            var dest = new decimal[] { 1, 3, 5, 7, 9 };
            
            var result = source.Merge(dest, x => x, x => x, x => (decimal)x).ToArray();

            CollectionAssert.AreEquivalent(result, source.Select(x => (decimal)x).ToArray());
        }
        
        [TestMethod]
        public void MergeAdd_OfDifferentTypes_YieldsCorrectResult()
        {
            var source = new [] { 1, 2, 3, 8, 9, 10 };
            var dest = new decimal[] { 1, 3, 5, 7, 9 };

            var result = source.MergeAdd(dest, x => x, x => x, x => (decimal)x).ToArray();

            CollectionAssert.AreEquivalent(result, new decimal[]{1, 2, 3, 5, 7, 8, 9, 10});
        }
    }
}
