using System;
using System.Collections.Generic;

namespace MergeHelper
{
    public static class MergeIntoExtensions
    {
        /// <summary>
        /// Merges source sequence of T into collection of T (add only)
        /// </summary>
        public static void MergeAddInto<T, TKey>(
            this IEnumerable<T> sourceSeq,
            ICollection<T> destCollection,
            Func<T, TKey> getKey)
        {
            sourceSeq.MergeAddInto(destCollection, getKey, getKey, x => x);
        }
        
        /// <summary>
        /// Merges source sequence of T into collection of T (add only)
        /// </summary>
        public static void MergeAddInto<T, TKey>(
            this IEnumerable<T> sourceSeq,
            ICollection<T> destCollection,
            Func<T, TKey> getKey,
            Func<T, T> mapAdd)
        {
            sourceSeq.MergeAddInto(destCollection, getKey, getKey, mapAdd);
        }
        
        /// <summary>
        /// Merges source sequence of T into collection of T (add only);
        /// with add event
        /// </summary>
        public static void MergeAddInto<T, TKey>(
            this IEnumerable<T> sourceSeq,
            ICollection<T> destCollection,
            Func<T, TKey> getKey,
            Action<T> onAdding)
        {
            sourceSeq.MergeAddInto(destCollection, getKey, getKey, x => x, onAdding);
        }

        /// <summary>
        /// Merges source sequence of T into collection of T (add only);
        /// with add event
        /// </summary>
        public static void MergeAddInto<T, TKey>(
            this IEnumerable<T> sourceSeq,
            ICollection<T> destCollection,
            Func<T, TKey> getKey,
            Func<T, T> mapAdd,
            Action<T> onAdding)
        {
            sourceSeq.MergeAddInto(destCollection, getKey, getKey, mapAdd, onAdding);
        }

        /// <summary>
        /// Merges source sequence of T into collection of T (add only);
        /// with conditional add event
        /// </summary>
        public static void MergeAddInto<T, TKey>(
            this IEnumerable<T> sourceSeq,
            ICollection<T> destCollection,
            Func<T, TKey> getKey,
            Func<T, bool> onAdding)
        {
            sourceSeq.MergeAddInto(destCollection, getKey, getKey, x => x, onAdding);
        }

        /// <summary>
        /// Merges source sequence of T into collection of T (add only);
        /// with conditional add event
        /// </summary>
        public static void MergeAddInto<T, TKey>(
            this IEnumerable<T> sourceSeq,
            ICollection<T> destCollection,
            Func<T, TKey> getKey,
            Func<T, T> mapAdd,
            Func<T, bool> onAdding)
        {
            sourceSeq.MergeAddInto(destCollection, getKey, getKey, mapAdd, onAdding);
        }
        
        /// <summary>
        /// Merges source sequence of T into collection of T (add / update only)
        /// </summary>
        public static void MergeAddOrUpdateInto<T, TKey>(
            this IEnumerable<T> sourceSeq,
            ICollection<T> destCollection,
            Func<T, TKey> getKey,
            Action<T, T> update)
        {
            sourceSeq.MergeAddOrUpdateInto(destCollection, getKey, getKey, x => x, update);
        }

        /// <summary>
        /// Merges source sequence of T into collection of T (add / update only)
        /// </summary>
        public static void MergeAddOrUpdateInto<T, TKey>(
            this IEnumerable<T> sourceSeq,
            ICollection<T> destCollection,
            Func<T, TKey> getKey,
            Func<T, T> mapAdd,
            Action<T, T> update)
        {
            sourceSeq.MergeAddOrUpdateInto(destCollection, getKey, getKey, mapAdd, update);
        }

        /// <summary>
        /// Merges source sequence of T into collection of T (add / update only);
        /// with add event
        /// </summary>
        public static void MergeAddOrUpdateInto<T, TKey>(
            this IEnumerable<T> sourceSeq,
            ICollection<T> destCollection,
            Func<T, TKey> getKey,
            Action<T, T> update,
            Action<T> onAdding)
        {
            sourceSeq.MergeAddOrUpdateInto(destCollection, getKey, getKey, x => x, update, onAdding);
        }

        /// <summary>
        /// Merges source sequence of T into collection of T (add / update only);
        /// with add event
        /// </summary>
        public static void MergeAddOrUpdateInto<T, TKey>(
            this IEnumerable<T> sourceSeq,
            ICollection<T> destCollection,
            Func<T, TKey> getKey,
            Func<T, T> mapAdd,
            Action<T, T> update,
            Action<T> onAdding)
        {
            sourceSeq.MergeAddOrUpdateInto(destCollection, getKey, getKey, mapAdd, update, onAdding);
        }

        /// <summary>
        /// Merges source sequence of T into collection of T (add / update only);
        /// with conditional add event
        /// </summary>
        public static void MergeAddOrUpdateInto<T, TKey>(
            this IEnumerable<T> sourceSeq,
            ICollection<T> destCollection,
            Func<T, TKey> getKey,
            Action<T, T> update,
            Func<T, bool> onAdding)
        {
            sourceSeq.MergeAddOrUpdateInto(destCollection, getKey, getKey, x => x, update, onAdding);
        }

        /// <summary>
        /// Merges source sequence of T into collection of T (add / update only);
        /// with conditional add event
        /// </summary>
        public static void MergeAddOrUpdateInto<T, TKey>(
            this IEnumerable<T> sourceSeq,
            ICollection<T> destCollection,
            Func<T, TKey> getKey,
            Func<T, T> mapAdd,
            Action<T, T> update,
            Func<T, bool> onAdding)
        {
            sourceSeq.MergeAddOrUpdateInto(destCollection, getKey, getKey, mapAdd, update, onAdding);
        }

        /// <summary>
        /// Merges source sequence of T into collection of T (add / delete only)
        /// </summary>
        public static void MergeInto<T, TKey>(
            this IEnumerable<T> sourceSeq,
            ICollection<T> destCollection,
            Func<T, TKey> getKey)
        {
            sourceSeq.MergeInto(destCollection, getKey, getKey, x => x);
        }

        /// <summary>
        /// Merges source sequence of T into collection of T (add / delete only)
        /// </summary>
        public static void MergeInto<T, TKey>(
            this IEnumerable<T> sourceSeq,
            ICollection<T> destCollection,
            Func<T, TKey> getKey,
            Func<T, T> mapAdd)
        {
            sourceSeq.MergeInto(destCollection, getKey, getKey, mapAdd);
        }

        /// <summary>
        /// Merges source sequence of T into collection of T (add / delete only);
        /// with add and delete events
        /// </summary>
        public static void MergeInto<T, TKey>(
            this IEnumerable<T> sourceSeq,
            ICollection<T> destCollection,
            Func<T, TKey> getKey,
            Action<T> onAdding,
            Action<T> onDeleting)
        {
            sourceSeq.MergeInto(destCollection, getKey, getKey, x => x, onAdding, onDeleting);
        }

        /// <summary>
        /// Merges source sequence of T into collection of T (add / delete only);
        /// with add and delete events
        /// </summary>
        public static void MergeInto<T, TKey>(
            this IEnumerable<T> sourceSeq,
            ICollection<T> destCollection,
            Func<T, TKey> getKey,
            Func<T, T> mapAdd,
            Action<T> onAdding,
            Action<T> onDeleting)
        {
            sourceSeq.MergeInto(destCollection, getKey, getKey, mapAdd, onAdding, onDeleting);
        }

        /// <summary>
        /// Merges source sequence of T into collection of T (add / delete only);
        /// with conditional add and delete events
        /// </summary>
        public static void MergeInto<T, TKey>(
            this IEnumerable<T> sourceSeq,
            ICollection<T> destCollection,
            Func<T, TKey> getKey,
            Func<T, bool> onAdding,
            Func<T, bool> onDeleting)
        {
            sourceSeq.MergeInto(destCollection, getKey, getKey, x => x, onAdding, onDeleting);
        }

        /// <summary>
        /// Merges source sequence of T into collection of T (add / delete only);
        /// with conditional add and delete events
        /// </summary>
        public static void MergeInto<T, TKey>(
            this IEnumerable<T> sourceSeq,
            ICollection<T> destCollection,
            Func<T, TKey> getKey,
            Func<T, T> mapAdd,
            Func<T, bool> onAdding,
            Func<T, bool> onDeleting)
        {
            sourceSeq.MergeInto(destCollection, getKey, getKey, mapAdd, onAdding, onDeleting);
        }

        /// <summary>
        /// Merges source sequence of T into collection of T (add / update / delete)
        /// </summary>
        public static void MergeInto<T, TKey>(
            this IEnumerable<T> sourceSeq,
            ICollection<T> destCollection,
            Func<T, TKey> getKey,
            Action<T, T> update)
        {
            sourceSeq.MergeInto(destCollection, getKey, getKey, x => x, update);
        }

        /// <summary>
        /// Merges source sequence of T into collection of T (add / update / delete)
        /// </summary>
        public static void MergeInto<T, TKey>(
            this IEnumerable<T> sourceSeq,
            ICollection<T> destCollection,
            Func<T, TKey> getKey,
            Func<T, T> mapAdd,
            Action<T, T> update)
        {
            sourceSeq.MergeInto(destCollection, getKey, getKey, mapAdd, update);
        }

        /// <summary>
        /// Merges source sequence of T into collection of T (add / update / delete);
        /// with add and delete events
        /// </summary>
        public static void MergeInto<T, TKey>(
            this IEnumerable<T> sourceSeq,
            ICollection<T> destCollection,
            Func<T, TKey> getKey,
            Action<T, T> update,
            Action<T> onAdding,
            Action<T> onDeleting)
        {
            sourceSeq.MergeInto(destCollection, getKey, getKey, x => x, update, onAdding, onDeleting);
        }

        /// <summary>
        /// Merges source sequence of T into collection of T (add / update / delete);
        /// with add and delete events
        /// </summary>
        public static void MergeInto<T, TKey>(
            this IEnumerable<T> sourceSeq,
            ICollection<T> destCollection,
            Func<T, TKey> getKey,
            Func<T, T> mapAdd,
            Action<T, T> update,
            Action<T> onAdding,
            Action<T> onDeleting)
        {
            sourceSeq.MergeInto(destCollection, getKey, getKey, mapAdd, update, onAdding, onDeleting);
        }

        /// <summary>
        /// Merges source sequence of T into collection of T (add / update / delete);
        /// with conditional add and delete events
        /// </summary>
        public static void MergeInto<T, TKey>(
            this IEnumerable<T> sourceSeq,
            ICollection<T> destCollection,
            Func<T, TKey> getKey,
            Action<T, T> update,
            Func<T, bool> onAdding,
            Func<T, bool> onDeleting)
        {
            sourceSeq.MergeInto(destCollection, getKey, getKey, x => x, update, onAdding, onDeleting);
        }

        /// <summary>
        /// Merges source sequence of T into collection of T (add / update / delete);
        /// with conditional add and delete events
        /// </summary>
        public static void MergeInto<T, TKey>(
            this IEnumerable<T> sourceSeq,
            ICollection<T> destCollection,
            Func<T, TKey> getKey,
            Func<T, T> mapAdd,
            Action<T, T> update,
            Func<T, bool> onAdding,
            Func<T, bool> onDeleting)
        {
            sourceSeq.MergeInto(destCollection, getKey, getKey, mapAdd, update, onAdding, onDeleting);
        }

        /// <summary>
        /// Merges source sequence of TSource into collection of TDest (add only)
        /// </summary>
        public static void MergeAddInto<TSource, TDest, TKey>(
            this IEnumerable<TSource> sourceSeq,
            ICollection<TDest> destCollection,
            Func<TSource, TKey> getKeyFromSource,
            Func<TDest, TKey> getKeyFromDest,
            Func<TSource, TDest> mapAdd)
        {
            sourceSeq.MergeAddOrUpdateInto(destCollection, getKeyFromSource, getKeyFromDest, mapAdd, (src, dest) => { }, src => true);
        }

        /// <summary>
        /// Merges source sequence of TSource into collection of TDest (add only);
        /// with add event
        /// </summary>
        public static void MergeAddInto<TSource, TDest, TKey>(
            this IEnumerable<TSource> sourceSeq,
            ICollection<TDest> destCollection,
            Func<TSource, TKey> getKeyFromSource,
            Func<TDest, TKey> getKeyFromDest,
            Func<TSource, TDest> mapAdd,
            Action<TSource> onAdding)
        {
            sourceSeq.MergeAddOrUpdateInto(destCollection, getKeyFromSource, getKeyFromDest, mapAdd, (src, dest) => { }, onAdding);
        }

        /// <summary>
        /// Merges source sequence of TSource into collection of TDest (add only);
        /// with conditional add event
        /// </summary>
        public static void MergeAddInto<TSource, TDest, TKey>(
            this IEnumerable<TSource> sourceSeq,
            ICollection<TDest> destCollection,
            Func<TSource, TKey> getKeyFromSource,
            Func<TDest, TKey> getKeyFromDest,
            Func<TSource, TDest> mapAdd,
            Func<TSource, bool> onAdding)
        {
            sourceSeq.MergeAddOrUpdateInto(destCollection, getKeyFromSource, getKeyFromDest, mapAdd, (src, dest) => { }, onAdding);
        }

        /// <summary>
        /// Merges source sequence of TSource into collection of TDest (add / update only)
        /// </summary>
        public static void MergeAddOrUpdateInto<TSource, TDest, TKey>(
            this IEnumerable<TSource> sourceSeq,
            ICollection<TDest> destCollection,
            Func<TSource, TKey> getKeyFromSource,
            Func<TDest, TKey> getKeyFromDest,
            Func<TSource, TDest> mapAdd,
            Action<TSource, TDest> update)
        {
            sourceSeq.MergeAddOrUpdateInto(destCollection, getKeyFromSource, getKeyFromDest, mapAdd, update, src => true);
        }

        /// <summary>
        /// Merges source sequence of TSource into collection of TDest (add / update only);
        /// with add event
        /// </summary>
        public static void MergeAddOrUpdateInto<TSource, TDest, TKey>(
            this IEnumerable<TSource> sourceSeq,
            ICollection<TDest> destCollection,
            Func<TSource, TKey> getKeyFromSource,
            Func<TDest, TKey> getKeyFromDest,
            Func<TSource, TDest> mapAdd,            
            Action<TSource, TDest> update, 
            Action<TSource> onAdding)
        {
            sourceSeq
                .MergeAddOrUpdateInto(
                    destCollection, 
                    getKeyFromSource, 
                    getKeyFromDest, 
                    mapAdd, 
                    update,
                    src => { onAdding(src); return true; });
        }

        /// <summary>
        /// Merges source sequence of TSource into collection of TDest (add / update only);
        /// with conditional add event
        /// </summary>
        public static void MergeAddOrUpdateInto<TSource, TDest, TKey>(
            this IEnumerable<TSource> sourceSeq,
            ICollection<TDest> destCollection,
            Func<TSource, TKey> getKeyFromSource,
            Func<TDest, TKey> getKeyFromDest,
            Func<TSource, TDest> mapAdd,
            Action<TSource, TDest> update,
            Func<TSource, bool> onAdding)
        {
            if (sourceSeq == null) throw new ArgumentNullException(nameof(sourceSeq));
            if (destCollection == null) throw new ArgumentNullException(nameof(destCollection));
            if (getKeyFromSource == null) throw new ArgumentNullException(nameof(getKeyFromSource));
            if (getKeyFromDest == null) throw new ArgumentNullException(nameof(getKeyFromDest));
            if (mapAdd == null) throw new ArgumentNullException(nameof(mapAdd));
            if (onAdding == null) throw new ArgumentNullException(nameof(onAdding));
            if (update == null) throw new ArgumentNullException(nameof(update));

            void add(TSource src)
            {
                if (onAdding(src))
                {
                    destCollection.Add(mapAdd(src));
                }
            }

            sourceSeq.ControlMerge(destCollection, getKeyFromSource, getKeyFromDest, add, update);
        }

        /// <summary>
        /// Merges source sequence of TSource into collection of TDest (add / delete only)
        /// </summary>
        public static void MergeInto<TSource, TDest, TKey>(
            this IEnumerable<TSource> sourceSeq,
            ICollection<TDest> destCollection,
            Func<TSource, TKey> getKeyFromSource,
            Func<TDest, TKey> getKeyFromDest,
            Func<TSource, TDest> mapAdd)
        {
            sourceSeq.MergeInto(destCollection, getKeyFromSource, getKeyFromDest, mapAdd, (src, dest) => { }, src => true, dest => true);
        }

        /// <summary>
        /// Merges source sequence of TSource into collection of TDest (add / delete only);
        /// with add and delete events
        /// </summary>
        public static void MergeInto<TSource, TDest, TKey>(
            this IEnumerable<TSource> sourceSeq,
            ICollection<TDest> destCollection,
            Func<TSource, TKey> getKeyFromSource,
            Func<TDest, TKey> getKeyFromDest,
            Func<TSource, TDest> mapAdd,
            Action<TSource> onAdding,
            Action<TDest> onDeleting)
        {
            sourceSeq.MergeInto(destCollection, getKeyFromSource, getKeyFromDest, mapAdd, (src, dest) => { }, onAdding, onDeleting);
        }

        /// <summary>
        /// Merges source sequence of TSource into collection of TDest (add / delete only);
        /// with conditional add and delete events
        /// </summary>
        public static void MergeInto<TSource, TDest, TKey>(
            this IEnumerable<TSource> sourceSeq,
            ICollection<TDest> destCollection,
            Func<TSource, TKey> getKeyFromSource,
            Func<TDest, TKey> getKeyFromDest,
            Func<TSource, TDest> mapAdd,
            Func<TSource, bool> onAdding,
            Func<TDest, bool> onDeleting)
        {
            sourceSeq.MergeInto(destCollection, getKeyFromSource, getKeyFromDest, mapAdd, (src, dest) => { }, onAdding, onDeleting);
        }

        /// <summary>
        /// Merges source sequence of TSource into collection of TDest (add / update / delete)
        /// </summary>
        public static void MergeInto<TSource, TDest, TKey>(
            this IEnumerable<TSource> sourceSeq,
            ICollection<TDest> destCollection,
            Func<TSource, TKey> getKeyFromSource,
            Func<TDest, TKey> getKeyFromDest,
            Func<TSource, TDest> mapAdd,
            Action<TSource, TDest> update)
        {
            sourceSeq.MergeInto(destCollection, getKeyFromSource, getKeyFromDest, mapAdd, update, src => true, dest => true);
        }

        /// <summary>
        /// Merges source sequence of TSource into collection of TDest (add / update / delete);
        /// with add and delete events
        /// </summary>
        public static void MergeInto<TSource, TDest, TKey>(
            this IEnumerable<TSource> sourceSeq,
            ICollection<TDest> destCollection,
            Func<TSource, TKey> getKeyFromSource,
            Func<TDest, TKey> getKeyFromDest,
            Func<TSource, TDest> mapAdd,
            Action<TSource, TDest> update,
            Action<TSource> onAdding,
            Action<TDest> onDeleting)
        {
            sourceSeq
                .MergeInto(
                    destCollection, 
                    getKeyFromSource, 
                    getKeyFromDest, 
                    mapAdd,
                    update,
                    src => { onAdding(src); return true; }, 
                    dest => { onDeleting(dest); return true; });
        }

        /// <summary>
        /// Merges source sequence of TSource into collection of TDest (add / update / delete);
        /// with conditional add and delete events
        /// </summary>
        public static void MergeInto<TSource, TDest, TKey>(
            this IEnumerable<TSource> sourceSeq,
            ICollection<TDest> destCollection,
            Func<TSource, TKey> getKeyFromSource,
            Func<TDest, TKey> getKeyFromDest,
            Func<TSource, TDest> mapAdd,
            Action<TSource, TDest> update,
            Func<TSource, bool> onAdding,
            Func<TDest, bool> onDeleting)
        {
            if (sourceSeq == null) throw new ArgumentNullException(nameof(sourceSeq));
            if (destCollection == null) throw new ArgumentNullException(nameof(destCollection));
            if (getKeyFromSource == null) throw new ArgumentNullException(nameof(getKeyFromSource));
            if (getKeyFromDest == null) throw new ArgumentNullException(nameof(getKeyFromDest));
            if (mapAdd == null) throw new ArgumentNullException(nameof(mapAdd));
            if (onAdding == null) throw new ArgumentNullException(nameof(onAdding));
            if (update == null) throw new ArgumentNullException(nameof(update));
            if (onDeleting == null) throw new ArgumentNullException(nameof(onDeleting));

            void add(TSource src)
            {
                if (onAdding(src))
                {
                    destCollection.Add(mapAdd(src));
                }
            }

            void delete(TDest dest)
            {
                if (onDeleting(dest))
                {
                    destCollection.Remove(dest);
                }
            }
            
            sourceSeq.ControlMerge(destCollection, getKeyFromSource, getKeyFromDest, add, update, delete);    
        }
    }
}
