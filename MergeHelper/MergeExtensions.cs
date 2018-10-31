using System;
using System.Collections.Generic;
using System.Linq;

namespace MergeHelper
{
    public static class MergeExtensions
    {
        /// <summary>
        /// Combines source sequence of T with destination sequence of T to create merged sequence of T (add only)
        /// </summary>
        public static IEnumerable<T> MergeAdd<T, TKey>(
            this IEnumerable<T> sourceSeq,
            IEnumerable<T> destSeq,
            Func<T, TKey> getKey)
        {
            return sourceSeq.MergeAdd(destSeq, getKey, getKey, x => x);
        }

        /// <summary>
        /// Combines source sequence of T with destination sequence of T to create merged sequence of T (add only)
        /// </summary>
        public static IEnumerable<T> MergeAdd<T, TKey>(
            this IEnumerable<T> sourceSeq,
            IEnumerable<T> destSeq,
            Func<T, TKey> getKey,
            Func<T, T> mapAdd)
        {
            return sourceSeq.MergeAdd(destSeq, getKey, getKey, mapAdd);
        }

        /// <summary>
        /// Combines source sequence of T with destination sequence of T to create merged sequence of T (add only);
        /// with add event
        /// </summary>
        public static IEnumerable<T> MergeAdd<T, TKey>(
            this IEnumerable<T> sourceSeq,
            IEnumerable<T> destSeq,
            Func<T, TKey> getKey,
            Action<T> onAdding)
        {
            return sourceSeq.MergeAdd(destSeq, getKey, getKey, x => x, onAdding);
        }

        /// <summary>
        /// Combines source sequence of T with destination sequence of T to create merged sequence of T (add only);
        /// with add event
        /// </summary>
        public static IEnumerable<T> MergeAdd<T, TKey>(
            this IEnumerable<T> sourceSeq,
            IEnumerable<T> destSeq,
            Func<T, TKey> getKey,
            Func<T, T> mapAdd,
            Action<T> onAdding)
        {
            return sourceSeq.MergeAdd(destSeq, getKey, getKey, mapAdd, onAdding);
        }

        /// <summary>
        /// Combines source sequence of T with destination sequence of T to create merged sequence of T (add only);
        /// with conditional add event
        /// </summary>
        public static IEnumerable<T> MergeAdd<T, TKey>(
            this IEnumerable<T> sourceSeq,
            IEnumerable<T> destSeq,
            Func<T, TKey> getKey,
            Func<T, bool> onAdding)
        {
            return sourceSeq.MergeAdd(destSeq, getKey, getKey, x => x, onAdding);
        }

        /// <summary>
        /// Combines source sequence of T with destination sequence of T to create merged sequence of T (add only);
        /// with conditional add event
        /// </summary>
        public static IEnumerable<T> MergeAdd<T, TKey>(
            this IEnumerable<T> sourceSeq,
            IEnumerable<T> destSeq,
            Func<T, TKey> getKey,
            Func<T, T> mapAdd,
            Func<T, bool> onAdding)
        {
            return sourceSeq.MergeAdd(destSeq, getKey, getKey, mapAdd, onAdding);
        }

        /// <summary>
        /// Combines source sequence of T with destination sequence of T to create merged sequence of T (add / update only)
        /// </summary>
        public static IEnumerable<T> MergeAddOrUpdate<T, TKey>(
            this IEnumerable<T> sourceSeq,
            IEnumerable<T> destSeq,
            Func<T, TKey> getKey,
            Func<T, T, T> mapUpdate)
        {
            return sourceSeq.MergeAddOrUpdate(destSeq, getKey, getKey, x => x, mapUpdate);
        }

        /// <summary>
        /// Combines source sequence of T with destination sequence of T to create merged sequence of T (add / update only)
        /// </summary>
        public static IEnumerable<T> MergeAddOrUpdate<T, TKey>(
            this IEnumerable<T> sourceSeq,
            IEnumerable<T> destSeq,
            Func<T, TKey> getKey,
            Func<T, T> mapAdd,
            Func<T, T, T> mapUpdate)
        {
            return sourceSeq.MergeAddOrUpdate(destSeq, getKey, getKey, mapAdd, mapUpdate);
        }

        /// <summary>
        /// Combines source sequence of T with destination sequence of T to create merged sequence of T (add / update only);
        /// with add and update events
        /// </summary>
        public static IEnumerable<T> MergeAddOrUpdate<T, TKey>(
            this IEnumerable<T> sourceSeq,
            IEnumerable<T> destSeq,
            Func<T, TKey> getKey,
            Func<T, T, T> mapUpdate,
            Action<T> onAdding,
            Action<T, T> onUpdating)
        {
            return sourceSeq.MergeAddOrUpdate(destSeq, getKey, getKey, x => x, mapUpdate, onAdding, onUpdating);
        }

        /// <summary>
        /// Combines source sequence of T with destination sequence of T to create merged sequence of T (add / update only);
        /// with add and update events
        /// </summary>
        public static IEnumerable<T> MergeAddOrUpdate<T, TKey>(
            this IEnumerable<T> sourceSeq,
            IEnumerable<T> destSeq,
            Func<T, TKey> getKey,
            Func<T, T> mapAdd,
            Func<T, T, T> mapUpdate,
            Action<T> onAdding,
            Action<T, T> onUpdating)
        {
            return sourceSeq.MergeAddOrUpdate(destSeq, getKey, getKey, mapAdd, mapUpdate, onAdding, onUpdating);
        }

        /// <summary>
        /// Combines source sequence of T with destination sequence of T to create merged sequence of T (add / update only);
        /// with conditional add and update events
        /// </summary>
        public static IEnumerable<T> MergeAddOrUpdate<T, TKey>(
            this IEnumerable<T> sourceSeq,
            IEnumerable<T> destSeq,
            Func<T, TKey> getKey,
            Func<T, T, T> mapUpdate,
            Func<T, bool> onAdding,
            Func<T, T, bool> onUpdating)
        {
            return sourceSeq.MergeAddOrUpdate(destSeq, getKey, getKey, x => x, mapUpdate, onAdding, onUpdating);
        }

        /// <summary>
        /// Combines source sequence of T with destination sequence of T to create merged sequence of T (add / update only);
        /// with conditional add and update events
        /// </summary>
        public static IEnumerable<T> MergeAddOrUpdate<T, TKey>(
            this IEnumerable<T> sourceSeq,
            IEnumerable<T> destSeq,
            Func<T, TKey> getKey,
            Func<T, T> mapAdd,
            Func<T, T, T> mapUpdate,
            Func<T, bool> onAdding,
            Func<T, T, bool> onUpdating)
        {
            return sourceSeq.MergeAddOrUpdate(destSeq, getKey, getKey, mapAdd, mapUpdate, onAdding, onUpdating);
        }

        /// <summary>
        /// Combines source sequence of T with destination sequence of T to create merged sequence of T (add / delete only)
        /// </summary>
        public static IEnumerable<T> Merge<T, TKey>(
            this IEnumerable<T> sourceSeq,
            IEnumerable<T> destSeq,
            Func<T, TKey> getKey)
        {
            return sourceSeq.Merge(destSeq, getKey, getKey, x => x);
        }

        /// <summary>
        /// Combines source sequence of T with destination sequence of T to create merged sequence of T (add / delete only)
        /// </summary>
        public static IEnumerable<T> Merge<T, TKey>(
            this IEnumerable<T> sourceSeq,
            IEnumerable<T> destSeq,
            Func<T, TKey> getKey,
            Func<T, T> mapAdd)
        {
            return sourceSeq.Merge(destSeq, getKey, getKey, mapAdd);
        }

        /// <summary>
        /// Combines source sequence of T with destination sequence of T to create merged sequence of T (add / delete only);
        /// with add and delete events
        /// </summary>
        public static IEnumerable<T> Merge<T, TKey>(
            this IEnumerable<T> sourceSeq,
            IEnumerable<T> destSeq,
            Func<T, TKey> getKey,
            Action<T> onAdding,
            Action<T> onDeleting)
        {
            return sourceSeq.Merge(destSeq, getKey, getKey, x => x, onAdding, onDeleting);
        }

        /// <summary>
        /// Combines source sequence of T with destination sequence of T to create merged sequence of T (add / delete only);
        /// with add and delete events
        /// </summary>
        public static IEnumerable<T> Merge<T, TKey>(
            this IEnumerable<T> sourceSeq,
            IEnumerable<T> destSeq,
            Func<T, TKey> getKey,
            Func<T, T> mapAdd,
            Action<T> onAdding,
            Action<T> onDeleting)
        {
            return sourceSeq.Merge(destSeq, getKey, getKey, mapAdd, onAdding, onDeleting);
        }

        /// <summary>
        /// Combines source sequence of T with destination sequence of T to create merged sequence of T (add / delete only);
        /// with conditional add and delete events
        /// </summary>
        public static IEnumerable<T> Merge<T, TKey>(
            this IEnumerable<T> sourceSeq,
            IEnumerable<T> destSeq,
            Func<T, TKey> getKey,
            Func<T, bool> onAdding,
            Func<T, bool> onDeleting)
        {
            return sourceSeq.Merge(destSeq, getKey, getKey, x => x, onAdding, onDeleting);
        }

        /// <summary>
        /// Combines source sequence of T with destination sequence of T to create merged sequence of T (add / delete only);
        /// with conditional add and delete events
        /// </summary>
        public static IEnumerable<T> Merge<T, TKey>(
            this IEnumerable<T> sourceSeq,
            IEnumerable<T> destSeq,
            Func<T, TKey> getKey,
            Func<T, T> mapAdd,
            Func<T, bool> onAdding,
            Func<T, bool> onDeleting)
        {
            return sourceSeq.Merge(destSeq, getKey, getKey, mapAdd, onAdding, onDeleting);
        }

        /// <summary>
        /// Combines source sequence of T with destination sequence of T to create merged sequence of T (add / update / delete)
        /// </summary>
        public static IEnumerable<T> Merge<T, TKey>(
            this IEnumerable<T> sourceSeq,
            IEnumerable<T> destSeq,
            Func<T, TKey> getKey,
            Func<T, T, T> mapUpdate)
        {
            return sourceSeq.Merge(destSeq, getKey, getKey, x => x, mapUpdate);
        }

        /// <summary>
        /// Combines source sequence of T with destination sequence of T to create merged sequence of T (add / update / delete)
        /// </summary>
        public static IEnumerable<T> Merge<T, TKey>(
            this IEnumerable<T> sourceSeq,
            IEnumerable<T> destSeq,
            Func<T, TKey> getKey,
            Func<T, T> mapAdd,
            Func<T, T, T> mapUpdate)
        {
            return sourceSeq.Merge(destSeq, getKey, getKey, mapAdd, mapUpdate);
        }

        /// <summary>
        /// Combines source sequence of T with destination sequence of T to create merged sequence of T (add / update / delete);
        /// with add, update, and delete events
        /// </summary>
        public static IEnumerable<T> Merge<T, TKey>(
            this IEnumerable<T> sourceSeq,
            IEnumerable<T> destSeq,
            Func<T, TKey> getKey,
            Func<T, T, T> mapUpdate,
            Action<T> onAdding,
            Action<T, T> onUpdating,
            Action<T> onDeleting)
        {
            return sourceSeq.Merge(destSeq, getKey, getKey, x => x, mapUpdate, onAdding, onUpdating, onDeleting);
        }

        /// <summary>
        /// Combines source sequence of T with destination sequence of T to create merged sequence of T (add / update / delete);
        /// with add, update, and delete events
        /// </summary>
        public static IEnumerable<T> Merge<T, TKey>(
            this IEnumerable<T> sourceSeq,
            IEnumerable<T> destSeq,
            Func<T, TKey> getKey,
            Func<T, T> mapAdd,
            Func<T, T, T> mapUpdate,
            Action<T> onAdding,
            Action<T, T> onUpdating,
            Action<T> onDeleting)
        {
            return sourceSeq.Merge(destSeq, getKey, getKey, mapAdd, mapUpdate, onAdding, onUpdating, onDeleting);
        }

        /// <summary>
        /// Combines source sequence of T with destination sequence of T to create merged sequence of T (add / update / delete);
        /// with conditional add, update, and delete events
        /// </summary>
        public static IEnumerable<T> Merge<T, TKey>(
            this IEnumerable<T> sourceSeq,
            IEnumerable<T> destSeq,
            Func<T, TKey> getKey,
            Func<T, T, T> mapUpdate,
            Func<T, bool> onAdding,
            Func<T, T, bool> onUpdating,
            Func<T, bool> onDeleting)
        {
            return sourceSeq.Merge(destSeq, getKey, getKey, x => x, mapUpdate, onAdding, onUpdating, onDeleting);
        }

        /// <summary>
        /// Combines source sequence of T with destination sequence of T to create merged sequence of T (add / update / delete);
        /// with conditional add, update, and delete events
        /// </summary>
        public static IEnumerable<T> Merge<T, TKey>(
            this IEnumerable<T> sourceSeq,
            IEnumerable<T> destSeq,
            Func<T, TKey> getKey,
            Func<T, T> mapAdd,
            Func<T, T, T> mapUpdate,
            Func<T, bool> onAdding,
            Func<T, T, bool> onUpdating,
            Func<T, bool> onDeleting)
        {
            return sourceSeq.Merge(destSeq, getKey, getKey, mapAdd, mapUpdate, onAdding, onUpdating, onDeleting);
        }

        /// <summary>
        /// Combines source sequence of TSource with destination sequence of TDest to create merged sequence of TDest (add only);
        /// with add event
        /// </summary>
        public static IEnumerable<TDest> MergeAdd<TSource, TDest, TKey>(
            this IEnumerable<TSource> sourceSeq,
            IEnumerable<TDest> destSeq,
            Func<TSource, TKey> getKeyFromSource,
            Func<TDest, TKey> getKeyFromDest,
            Func<TSource, TDest> mapAdd)
        {
            return sourceSeq.MergeAddOrUpdate(destSeq, getKeyFromSource, getKeyFromDest, mapAdd, (src, dest) => dest, src => true, (src, dest) => true);
        }

        /// <summary>
        /// Combines source sequence of TSource with destination sequence of TDest to create merged sequence of TDest (add only);
        /// with add event
        /// </summary>
        public static IEnumerable<TDest> MergeAdd<TSource, TDest, TKey>(
            this IEnumerable<TSource> sourceSeq,
            IEnumerable<TDest> destSeq,
            Func<TSource, TKey> getKeyFromSource,
            Func<TDest, TKey> getKeyFromDest,
            Func<TSource, TDest> mapAdd,
            Action<TSource> onAdding)
        {
            return sourceSeq.MergeAddOrUpdate(destSeq, getKeyFromSource, getKeyFromDest, mapAdd, (src, dest) => dest, onAdding, (src, dest) => { });
        }

        /// <summary>
        /// Combines source sequence of TSource with destination sequence of TDest to create merged sequence of TDest (add only);
        /// with conditional add event
        /// </summary>
        public static IEnumerable<TDest> MergeAdd<TSource, TDest, TKey>(
            this IEnumerable<TSource> sourceSeq,
            IEnumerable<TDest> destSeq,
            Func<TSource, TKey> getKeyFromSource,
            Func<TDest, TKey> getKeyFromDest,
            Func<TSource, TDest> mapAdd,
            Func<TSource, bool> onAdding)
        {
            return sourceSeq.MergeAddOrUpdate(destSeq, getKeyFromSource, getKeyFromDest, mapAdd, (src,dest) => dest, onAdding, (src,dest) => true);
        }

        /// <summary>
        /// Combines source sequence of TSource with destination sequence of TDest to create merged sequence of TDest (add / update only)
        /// </summary>
        public static IEnumerable<TDest> MergeAddOrUpdate<TSource, TDest, TKey>(
            this IEnumerable<TSource> sourceSeq,
            IEnumerable<TDest> destSeq,
            Func<TSource, TKey> getKeyFromSource,
            Func<TDest, TKey> getKeyFromDest,
            Func<TSource, TDest> mapAdd,
            Func<TSource, TDest, TDest> mapUpdate)
        {
            return sourceSeq.MergeAddOrUpdate(destSeq, getKeyFromSource, getKeyFromDest, mapAdd, mapUpdate, src => true, (src,dest) => true);
        }

        /// <summary>
        /// Combines source sequence of TSource with destination sequence of TDest to create merged sequence of TDest (add / update only);
        /// with add and update events
        /// </summary>
        public static IEnumerable<TDest> MergeAddOrUpdate<TSource, TDest, TKey>(
            this IEnumerable<TSource> sourceSeq,
            IEnumerable<TDest> destSeq,
            Func<TSource, TKey> getKeyFromSource,
            Func<TDest, TKey> getKeyFromDest,
            Func<TSource, TDest> mapAdd,
            Func<TSource, TDest, TDest> mapUpdate,
            Action<TSource> onAdding,
            Action<TSource, TDest> onUpdating)
        {
            return sourceSeq
                .MergeAddOrUpdate(
                    destSeq, 
                    getKeyFromSource, 
                    getKeyFromDest, 
                    mapAdd, 
                    mapUpdate,
                    src => { onAdding(src); return true;},
                    (src, dest) => { onUpdating(src, dest); return true;});
        }

        /// <summary>
        /// Combines source sequence of TSource with destination sequence of TDest to create merged sequence of TDest (add / update only);
        /// with conditional add and update events
        /// </summary>
        public static IEnumerable<TDest> MergeAddOrUpdate<TSource, TDest, TKey>(
            this IEnumerable<TSource> sourceSeq,
            IEnumerable<TDest> destSeq,
            Func<TSource, TKey> getKeyFromSource,
            Func<TDest, TKey> getKeyFromDest,
            Func<TSource, TDest> mapAdd,
            Func<TSource, TDest, TDest> mapUpdate,
            Func<TSource, bool> onAdding,
            Func<TSource, TDest, bool> onUpdating)
        {
            return sourceSeq.Merge(destSeq, getKeyFromSource, getKeyFromDest, mapAdd, mapUpdate, onAdding, onUpdating, dest => false);
        }

        /// <summary>
        /// Combines source sequence of TSource with destination sequence of TDest to create merged sequence of TDest (add / delete only)
        /// </summary>
        public static IEnumerable<TDest> Merge<TSource, TDest, TKey>(
            this IEnumerable<TSource> sourceSeq,
            IEnumerable<TDest> destSeq,
            Func<TSource, TKey> getKeyFromSource,
            Func<TDest, TKey> getKeyFromDest,
            Func<TSource, TDest> mapAdd)
        {
            return sourceSeq.Merge(destSeq, getKeyFromSource, getKeyFromDest, mapAdd, (src, dest) => dest, src => true, (src,dest) => true, dest => true);
        }

        /// <summary>
        /// Combines source sequence of TSource with destination sequence of TDest to create merged sequence of TDest (add / delete only);
        /// with add and delete events
        /// </summary>
        public static IEnumerable<TDest> Merge<TSource, TDest, TKey>(
            this IEnumerable<TSource> sourceSeq,
            IEnumerable<TDest> destSeq,
            Func<TSource, TKey> getKeyFromSource,
            Func<TDest, TKey> getKeyFromDest,
            Func<TSource, TDest> mapAdd,
            Action<TSource> onAdding,
            Action<TDest> onDeleting)
        {
            return sourceSeq.Merge(destSeq, getKeyFromSource, getKeyFromDest, mapAdd, (src, dest) => dest, onAdding, (src, dest) => {}, onDeleting);
        }

        /// <summary>
        /// Combines source sequence of TSource with destination sequence of TDest to create merged sequence of TDest (add / delete only);
        /// with conditional add and delete events
        /// </summary>
        public static IEnumerable<TDest> Merge<TSource, TDest, TKey>(
            this IEnumerable<TSource> sourceSeq,
            IEnumerable<TDest> destSeq,
            Func<TSource, TKey> getKeyFromSource,
            Func<TDest, TKey> getKeyFromDest,
            Func<TSource, TDest> mapAdd,
            Func<TSource, bool> onAdding,
            Func<TDest, bool> onDeleting)
        {
            return sourceSeq.Merge(destSeq, getKeyFromSource, getKeyFromDest, mapAdd, (src, dest) => dest, onAdding, (src,dest) => true, onDeleting);
        }

        /// <summary>
        /// Combines source sequence of TSource with destination sequence of TDest to create merged sequence of TDest (add / update / delete)
        /// </summary>
        public static IEnumerable<TDest> Merge<TSource, TDest, TKey>(
            this IEnumerable<TSource> sourceSeq,
            IEnumerable<TDest> destSeq,
            Func<TSource, TKey> getKeyFromSource,
            Func<TDest, TKey> getKeyFromDest,
            Func<TSource, TDest> mapAdd,
            Func<TSource, TDest, TDest> mapUpdate)
        {
            return sourceSeq.Merge(destSeq, getKeyFromSource, getKeyFromDest, mapAdd, mapUpdate, src => true, (src, dest) => true, dest => true);
        }

        /// <summary>
        /// Combines source sequence of TSource with destination sequence of TDest to create merged sequence of TDest (add / update / delete);
        /// with add, update, and delete events
        /// </summary>
        public static IEnumerable<TDest> Merge<TSource, TDest, TKey>(
            this IEnumerable<TSource> sourceSeq,
            IEnumerable<TDest> destSeq,
            Func<TSource, TKey> getKeyFromSource,
            Func<TDest, TKey> getKeyFromDest,
            Func<TSource, TDest> mapAdd,
            Func<TSource, TDest, TDest> mapUpdate,
            Action<TSource> onAdding,
            Action<TSource, TDest> onUpdating,
            Action<TDest> onDeleting)
        {
            return sourceSeq
                .Merge(destSeq, 
                    getKeyFromSource, 
                    getKeyFromDest, 
                    mapAdd, 
                    mapUpdate, 
                    src => { onAdding(src); return true;},
                    (src, dest) => { onUpdating(src, dest); return true; },
                    dest => { onDeleting(dest); return true;});
        }

        /// <summary>
        /// Combines source sequence of TSource with destination sequence of TDest to create merged sequence of TDest (add / update / delete);
        /// with conditional add, update, and delete events
        /// </summary>
        public static IEnumerable<TDest> Merge<TSource, TDest, TKey>(
            this IEnumerable<TSource> sourceSeq,
            IEnumerable<TDest> destSeq,
            Func<TSource, TKey> getKeyFromSource,
            Func<TDest, TKey> getKeyFromDest,
            Func<TSource, TDest> mapAdd,
            Func<TSource, TDest, TDest> mapUpdate,
            Func<TSource, bool> onAdding,
            Func<TSource, TDest, bool> onUpdating,
            Func<TDest, bool> onDeleting)
        {
            if (sourceSeq == null) throw new ArgumentNullException(nameof(sourceSeq));
            if (destSeq == null) throw new ArgumentNullException(nameof(destSeq));
            if (getKeyFromSource == null) throw new ArgumentNullException(nameof(getKeyFromSource));
            if (getKeyFromDest == null) throw new ArgumentNullException(nameof(getKeyFromDest));
            if (mapAdd == null) throw new ArgumentNullException(nameof(mapAdd));
            if (onAdding == null) throw new ArgumentNullException(nameof(onAdding));
            if (onUpdating == null) throw new ArgumentNullException(nameof(onUpdating));
            if (onDeleting == null) throw new ArgumentNullException(nameof(onDeleting));

            var destCopy = destSeq.ToArray();

            var destMap = destCopy.GetIdentityMap(getKeyFromDest);

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
                    // match found:

                    if (!onUpdating(sourceItem, matchingDestItem))
                    {
                        // not allowed to be updated
                        yield return matchingDestItem;
                    }
                    else
                    {
                        // allowed to be updated
                        yield return mapUpdate(sourceItem, matchingDestItem);
                    }
                }
                else if (onAdding(sourceItem))
                {
                    yield return mapAdd(sourceItem);
                }
            }

            foreach (var destItem in destCopy)
            {
                var destKey = getKeyFromDest(destItem);

                if (destKey.Equals(default(TKey)))
                {
                    // always include items with default key in output
                    yield return destItem;
                }

                if (sourceKeys.Contains(destKey))
                {
                    // has match in source; already handled previously
                    continue;
                }

                if (onDeleting(destItem))
                {
                    // no match in source and allowed to "delete" : ignore in output
                    continue;
                }
                
                // no match in source but not allowed to "delete" : must include in output
                yield return destItem;
            }
        }
    }
}
