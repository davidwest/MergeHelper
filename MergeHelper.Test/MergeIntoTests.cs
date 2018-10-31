using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MergeHelper.Test
{
    [TestClass]
    public class MergeIntoTests
    {
        [TestMethod]
        public void MergeInto_OfSameType_TransformsDestinationCorrectly()
        {
            var source = new[] { 1, 2, 3, 8, 9, 10 };
            var dest = new List<int> { 1, 3, 5, 7, 9 };

            source.MergeInto(dest, x => x);

            CollectionAssert.AreEquivalent(dest, source);
        }
        
        [TestMethod]
        public void MergeInto_OfSameType_HandlesUnconditionalEventsCorrectly()
        {
            var source = new[] { 1, 2, 3, 8, 9, 10 };
            var dest = new List<int> { 1, 3, 5, 7, 9 };

            var matches = new List<int>();
            var adds = new List<int>();
            var removals = new List<int>();

            source
                .MergeInto(dest, 
                           x => x,
                           (s, d) => matches.Add(s),
                           toAdd => adds.Add(toAdd),
                           toRemove => removals.Add(toRemove));

            CollectionAssert.AreEquivalent(adds, new []{2, 8, 10});
            CollectionAssert.AreEquivalent(removals, new []{5, 7});
            CollectionAssert.AreEquivalent(matches, new[] { 1, 3, 9 });
        }

        [TestMethod]
        public void MergeInto_OfSameType_HandlesConditionalEventsCorrectly()
        {
            var source = new[] { 1, 2, 3, 8, 9, 10 };
            var dest = new List<int> { 1, 3, 5, 7, 9 };
            
            source
                .MergeInto(dest,
                    x => x,
                    toAdd => toAdd != 10,
                    toRemove => toRemove != 7);

            CollectionAssert.AreEquivalent(dest, new []{1, 2, 3, 7, 8, 9});
        }
        
        [TestMethod]
        public void MergeAddInto_OfSameType_TransformsDestinationCorrectly()
        {
            var source = new[] { 1, 2, 3, 8, 9, 10 };
            var dest = new List<int> { 1, 3, 5, 7, 9 };
            
            source.MergeAddInto(dest, x => x);

            CollectionAssert.AreEquivalent(dest, new []{1, 2, 3, 5, 7, 8, 9, 10});
        }
        
        [TestMethod]
        public void MergeAddOrUpdateInto_OfSameType_HandlesUnconditionalEventsCorrectly()
        {
            var source = new[] { 1, 2, 3, 8, 9, 10 };
            var dest = new List<int> { 1, 3, 5, 7, 9 };
            
            var matches = new List<int>();
            var adds = new List<int>();

            source
                .MergeAddOrUpdateInto(
                    dest,
                    x => x,
                    (s, d) => matches.Add(s),
                    toAdd => adds.Add(toAdd));

            CollectionAssert.AreEquivalent(adds, new[] { 2, 8, 10 });
            CollectionAssert.AreEquivalent(matches, new[] { 1, 3, 9 });
        }
        
        [TestMethod]
        public void MergeAddInto_OfSameType_HandlesConditionalEventsCorrectly()
        {
            var source = new[] { 1, 2, 3, 8, 9, 10 };
            var dest = new List<int> { 1, 3, 5, 7, 9 };
            
            source.MergeAddInto(dest, x => x, toAdd => toAdd != 10);

            CollectionAssert.AreEquivalent(dest, new[] { 1, 2, 3, 5, 7, 8, 9 });
        }

        [TestMethod]
        public void MergeInto_OfSameType_HandlesMappingCorrectly()
        {
            var source = new[] { 1, 2, 3, 8, 9, 10 };
            var dest = new List<int> { 1, 3, 5, 7, 9 };

            source.MergeInto(dest, x => x, x => -x);

            CollectionAssert.AreEquivalent(dest, new []{1, -2, 3, -8, 9, -10});
        }
        
        [TestMethod]
        public void MergeAddInto_OfSameType_HandlesMappingCorrectly()
        {
            var source = new[] { 1, 2, 3, 8, 9, 10 };
            var dest = new List<int> { 1, 3, 5, 7, 9 };

            source.MergeAddInto(dest, x => x, x => -x);
            
            CollectionAssert.AreEquivalent(dest, new[] { 1, -2, 3, 5, 7, -8, 9, -10 });
        }
        
        [TestMethod]
        public void MergeInto_OfSameType_WithDefaultKeys_TransformsDestinationCorrectly()
        {
            var source = new[] { 0, 0, 0, 1, 2, 3, 8, 9, 10 };
            var dest = new List<int> { 0, 0, 0, 1, 3, 5, 7, 9 };

            source.MergeInto(dest, x => x);

            CollectionAssert.AreEquivalent(dest, new []{0, 0, 0, 0, 0, 0, 1, 2, 3, 8, 9, 10});
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MergeInto_OfSameType_WithSourceDuplicateNonDefaultKeys_ThrowsException()
        {
            var source = new[] { 1, 1, 2, 3, 8, 9, 10 };
            var dest = new List<int> { 1, 3, 5, 7, 9 };

            source.MergeInto(dest, x => x);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MergeInto_OfSameType_WithDestDuplicateNonDefaultKeys_ThrowsException()
        {
            var source = new[] { 1, 2, 3, 8, 9, 10 };
            var dest = new List<int> { 1, 1, 3, 5, 7, 9 };

            source.MergeInto(dest, x => x);
        }

        [TestMethod]
        public void MergeInto_OfDifferentTypes_TransformsDestinationCorrectly()
        {
            var source = new[] { 1, 2, 3, 8, 9, 10 };
            var dest = new List<decimal> { 1, 3, 5, 7, 9 };

            source.MergeInto(dest, x => x, x => x, x => (decimal)x);

            CollectionAssert.AreEquivalent(dest, source.Select(x => (decimal)x).ToArray());
        }
        
        [TestMethod]
        public void MergeAddInto_OfDifferentTypes_TransformsDestinationCorrectly()
        {
            var source = new[] { 1, 2, 3, 8, 9, 10 };
            var dest = new List<decimal> { 1, 3, 5, 7, 9 };

            source.MergeAddInto(dest, x => x, x => x, x => (decimal)x);

            CollectionAssert.AreEquivalent(dest, new decimal[]{1, 2, 3, 5, 7, 8, 9, 10});
        }
    }
}
