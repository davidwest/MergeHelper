using System;
using System.Collections.Generic;

namespace MergeHelper
{
    public abstract class MergerBase<TBuilder, T, TKey> : MasterMergerBase<TBuilder, T, TKey>
        where TBuilder : MergerBase<TBuilder, T, TKey>
    {
        private Func<T, T> _mapAddCallback = x => x;
        private Func<T, T, T> _mapUpdateCallback = (x,y) => y;
        private Func<T, bool> _addingCallback = x => true;
        private Func<T, T, bool> _updatingCallback = (x,y) => true;
        private Func<T, bool> _deletingCallback = x => true;

        public TBuilder MapAdd(Func<T,T> mapAddCallback)
        {
            _mapAddCallback = mapAddCallback ?? (x => x);
            return (TBuilder)this;
        }
        
        public TBuilder MapUpdate(Func<T, T, T> mapUpdateCallback)
        {
            _mapUpdateCallback = mapUpdateCallback ?? ((x,y) => y);
            return (TBuilder)this;
        }

        public TBuilder OnAdding(Action<T> addingCallback)
        {
            return OnAdding(item =>
            {
                addingCallback?.Invoke(item);
                return true;
            });
        }

        public TBuilder OnAdding(Func<T, bool> addingCallback)
        {
            _addingCallback = addingCallback ?? (x => true);
            return (TBuilder)this;
        }

        public TBuilder OnUpdating(Action<T, T> updatingCallback)
        {
            return OnUpdating((src, dest) =>
            {
                updatingCallback?.Invoke(src, dest);
                return true;
            });
        }

        public TBuilder OnUpdating(Func<T, T, bool> updatingCallback)
        {
            _updatingCallback = updatingCallback ?? ((x, y) => true);
            return (TBuilder)this;
        }

        public TBuilder OnDeleting(Action<T> deletingCallback)
        {
            return OnDeleting(item =>
            {
                deletingCallback?.Invoke(item);
                return true;
            });
        }

        public TBuilder OnDeleting(Func<T, bool> deletingCallback)
        {
            _deletingCallback = deletingCallback ?? (x => true);
            return (TBuilder)this;
        }

        public IEnumerable<T> Merge(IEnumerable<T> destSeq)
        {
            return _source.Merge(destSeq, _getKey, _mapAddCallback, _mapUpdateCallback, _addingCallback,_updatingCallback, _deletingCallback);
        }
    }

    public class Merger<T, TKey> : MergerBase<Merger<T, TKey>, T, TKey>
    { }

    public class Merger<T> : MergerBase<Merger<T>, T, object>
    {
        public Merger()
        {
            WithKey(item => item);
        }
    }
}
