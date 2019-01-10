using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MergeHelper
{
    public static class ControlMergeExtensions
    {
        /// <summary>
        /// Invokes add, update, and (optionally) delete callbacks while combining source sequence of T with destination sequence of T
        /// </summary>
        public static void ControlMerge<T, TKey>(
            this IEnumerable<T> sourceSeq,
            IEnumerable<T> destSeq,
            Func<T, TKey> getKey,
            Action<T> add,
            Action<T, T> update,
            Action<T> delete = null)
        {
            sourceSeq.ControlMerge(destSeq, getKey, getKey, add, update, delete);
        }

        /// <summary>
        /// Invokes add, update, and (optionally) delete callbacks while combining source sequence of TSource with destination sequence of TDest
        /// </summary>
        public static void ControlMerge<TSource, TDest, TKey>(
            this IEnumerable<TSource> sourceSeq,
            IEnumerable<TDest> destSeq,
            Func<TSource, TKey> getKeyFromSource,
            Func<TDest, TKey> getKeyFromDest,
            Action<TSource> add,
            Action<TSource, TDest> update,
            Action<TDest> delete = null)
        {
            if (sourceSeq == null) throw new ArgumentNullException(nameof(sourceSeq));
            if (destSeq == null) throw new ArgumentNullException(nameof(destSeq));
            if (getKeyFromSource == null) throw new ArgumentNullException(nameof(getKeyFromSource));
            if (getKeyFromDest == null) throw new ArgumentNullException(nameof(getKeyFromDest));
            if (add == null) throw new ArgumentNullException(nameof(add));
            if (update == null) throw new ArgumentNullException(nameof(update));

            var destCopy = delete != null ? destSeq.ToArray() : null;
            
            var destMap = (destCopy ?? destSeq).GetIdentityMap(getKeyFromDest);

            var sourceKeys = new HashSet<TKey>();

            foreach (var sourceItem in sourceSeq)
            {
                var sourceKey = getKeyFromSource(sourceItem);

                if (sourceKeys.Contains(sourceKey))
                {
                    throw new ArgumentException("Duplicate key inserted", nameof(sourceSeq));
                }

                if (!sourceKey.Equals(default(TKey)))
                {
                    sourceKeys.Add(sourceKey);
                }
                
                if (destMap.TryGetValue(sourceKey, out var matchingDestItem))
                {
                    update(sourceItem, matchingDestItem);
                }
                else
                {
                    add(sourceItem);
                }
            }

            if (delete == null) return;

            foreach (var destItem in destCopy)
            {
                var destKey = getKeyFromDest(destItem);

                if (destKey.Equals(default(TKey)))
                {
                    // ignore items with default key
                    continue;
                }

                if (sourceKeys.Contains(destKey))
                {
                    // has match in source; do not delete
                    continue;
                }
                
                // no match in source
                delete(destItem);
            }
        }

        /// <summary>
        /// Invokes add, update, and (optionally) delete callbacks while combining source sequence of T with destination sequence of T (parallel)
        /// </summary>
        public static void ControlMergeParallel<T, TKey>(
            this IEnumerable<T> sourceSeq,
            IEnumerable<T> destSeq,
            Func<T, TKey> getKey,
            Action<T> add,
            Action<T, T> update,
            Action<T> delete = null)
        {
            sourceSeq.ControlMergeParallel(new ParallelOptions(), destSeq, getKey, getKey, add, update, delete);
        }

        /// <summary>
        /// Invokes add, update, and (optionally) delete callbacks while combining source sequence of T with destination sequence of T (parallel)
        /// </summary>
        public static void ControlMergeParallel<T, TKey>(
            this IEnumerable<T> sourceSeq,
            ParallelOptions options,
            IEnumerable<T> destSeq,
            Func<T, TKey> getKey,
            Action<T> add,
            Action<T, T> update,
            Action<T> delete = null)
        {
            sourceSeq.ControlMergeParallel(options, destSeq, getKey, getKey, add, update, delete);
        }

        /// <summary>
        /// Invokes add, update, and (optionally) delete callbacks while combining source sequence of TSource with destination sequence of TDest (parallel)
        /// </summary>
        public static void ControlMergeParallel<TSource, TDest, TKey>(
            this IEnumerable<TSource> sourceSeq,
            IEnumerable<TDest> destSeq,
            Func<TSource, TKey> getKeyFromSource,
            Func<TDest, TKey> getKeyFromDest,
            Action<TSource> add,
            Action<TSource, TDest> update,
            Action<TDest> delete = null)
        {
            sourceSeq.ControlMergeParallel(new ParallelOptions(), destSeq, getKeyFromSource, getKeyFromDest, add, update, delete);
        }

        /// <summary>
        /// Invokes add, update, and (optionally) delete callbacks while combining source sequence of TSource with destination sequence of TDest (parallel)
        /// </summary>
        public static void ControlMergeParallel<TSource, TDest, TKey>(
            this IEnumerable<TSource> sourceSeq,
            ParallelOptions options,
            IEnumerable<TDest> destSeq,
            Func<TSource, TKey> getKeyFromSource,
            Func<TDest, TKey> getKeyFromDest,
            Action<TSource> add,
            Action<TSource, TDest> update,
            Action<TDest> delete = null)
        {
            if (sourceSeq == null) throw new ArgumentNullException(nameof(sourceSeq));
            if (destSeq == null) throw new ArgumentNullException(nameof(destSeq));
            if (getKeyFromSource == null) throw new ArgumentNullException(nameof(getKeyFromSource));
            if (getKeyFromDest == null) throw new ArgumentNullException(nameof(getKeyFromDest));
            if (add == null) throw new ArgumentNullException(nameof(add));
            if (update == null) throw new ArgumentNullException(nameof(update));

            var destCopy = delete != null ? destSeq.ToArray() : null;

            var destMap = (destCopy ?? destSeq).GetIdentityMap(getKeyFromDest);

            var sourceKeys = new ConcurrentDictionary<TKey, TKey>();

            Parallel.ForEach(sourceSeq, options, sourceItem =>
            {
                var sourceKey = getKeyFromSource(sourceItem);

                if (!sourceKey.Equals(default(TKey)))
                {
                    if (!sourceKeys.TryAdd(sourceKey, sourceKey))
                    {
                        throw new ArgumentException("Duplicate key inserted", nameof(sourceSeq));
                    }
                }

                if (destMap.TryGetValue(sourceKey, out var matchingDestItem))
                {
                    update(sourceItem, matchingDestItem);
                }
                else
                {
                    add(sourceItem);
                }
            });

            if (delete == null) return;

            Parallel.ForEach(destCopy, options, destItem =>
            {
                var destKey = getKeyFromDest(destItem);

                if (destKey.Equals(default(TKey)))
                {
                    // ignore items with default key
                    return;
                }

                if (sourceKeys.ContainsKey(destKey))
                {
                    // has match in source; do not delete
                    return;
                }

                // no match in source
                delete(destItem);
            });
        }
        
        internal static Dictionary<TKey, T> GetIdentityMap<T, TKey>(this IEnumerable<T> seq, Func<T, TKey> getKey)
        {
            return seq.WithoutDefaultKeys(getKey).ToDictionary(item => getKey(item), item => item);
        }

        private static IEnumerable<T> WithoutDefaultKeys<T, TKey>(this IEnumerable<T> seq, Func<T, TKey> getKey)
        {
            return seq.Where(item => !getKey(item).Equals(default(TKey)));
        }
    }
}
