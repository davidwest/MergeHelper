using System;
using System.Collections.Generic;

namespace MergeHelper
{
    public abstract class InPlaceMergerBase<TBuilder, TSource, TDest, TKey> : MasterMergerBase<TBuilder, TSource, TDest, TKey>
        where TBuilder : InPlaceMergerBase<TBuilder, TSource, TDest, TKey>
    {
        private Func<TSource, TDest> _mapAddCallback;
        private Action<TSource, TDest> _updateCallback = (x, y) => { };
        private Func<TSource, bool> _addingCallback = x => true;
        private Func<TDest, bool> _deletingCallback = x => true;

        public TBuilder MapAdd(Func<TSource, TDest> mapAddCallback)
        {
            _mapAddCallback = mapAddCallback;
            return (TBuilder)this;
        }

        public TBuilder Update(Action<TSource, TDest> updateCallback)
        {
            _updateCallback = updateCallback ?? ((x, y) => { });
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

        public void MergeInto(ICollection<TDest> destCollection)
        {
            _source.MergeInto(destCollection, _getSourceKey, _getDestKey, _mapAddCallback, _updateCallback, _addingCallback, _deletingCallback);
        }
    }
    
    public class InPlaceMerger<TSource, TDest, TKey> : InPlaceMergerBase<InPlaceMerger<TSource, TDest, TKey>, TSource, TDest, TKey>
    { }
}
