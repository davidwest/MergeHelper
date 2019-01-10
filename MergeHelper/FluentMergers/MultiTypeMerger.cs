using System;
using System.Collections.Generic;

namespace MergeHelper
{
    public abstract class MergerBase<TBuilder, TSource, TDest, TKey> : MasterMergerBase<TBuilder, TSource, TDest, TKey>
        where TBuilder : MergerBase<TBuilder, TSource, TDest, TKey>
    {
        private Func<TSource, TDest> _mapAddCallback;
        private Func<TSource, TDest, TDest> _mapUpdateCallback = (x,y) => y;
        private Func<TSource, bool> _addingCallback = x => true;
        private Func<TSource, TDest, bool> _updatingCallback = (x,y) => true;
        private Func<TDest, bool> _deletingCallback = x => true;

        public TBuilder MapAdd(Func<TSource, TDest> mapAddCallback)
        {
            _mapAddCallback = mapAddCallback;
            return (TBuilder)this;
        }
        
        public TBuilder MapUpdate(Func<TSource, TDest, TDest> mapUpdateCallback)
        {
            _mapUpdateCallback = mapUpdateCallback ?? ((x,y) => y);
            return (TBuilder)this;
        }

        public TBuilder OnAdding(Action<TSource> addingCallback)
        {
            return OnAdding(item =>
            {
                addingCallback?.Invoke(item);
                return true;
            });
        }

        public TBuilder OnAdding(Func<TSource, bool> addingCallback)
        {
            _addingCallback = addingCallback ?? (x => true);
            return (TBuilder)this;
        }

        public TBuilder OnUpdating(Action<TSource, TDest> updatingCallback)
        {
            return OnUpdating((src, dest) =>
            {
                updatingCallback?.Invoke(src, dest);
                return true;
            });
        }

        public TBuilder OnUpdating(Func<TSource, TDest, bool> updatingCallback)
        {
            _updatingCallback = updatingCallback ?? ((x, y) => true);
            return (TBuilder)this;
        }

        public TBuilder OnDeleting(Action<TDest> deletingCallback)
        {
            return OnDeleting(item =>
            {
                deletingCallback?.Invoke(item);
                return true;
            });
        }

        public TBuilder OnDeleting(Func<TDest, bool> deletingCallback)
        {
            _deletingCallback = deletingCallback ?? (x => true);
            return (TBuilder)this;
        }

        public IEnumerable<TDest> Merge(IEnumerable<TDest> destSeq)
        {
            return _source.Merge(destSeq, _getSourceKey, _getDestKey, _mapAddCallback, _mapUpdateCallback, _addingCallback,_updatingCallback, _deletingCallback);
        }
    }
    
    public class Merger<TSource, TDest, TKey> : MergerBase<Merger<TSource, TDest, TKey>, TSource, TDest, TKey>
    { }
}
