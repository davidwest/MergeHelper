using System;
using System.Collections.Generic;

namespace MergeHelper
{
    public abstract class InPlaceMergerBase<TBuilder, T, TKey> : MasterMergerBase<TBuilder, T, TKey>
        where TBuilder : InPlaceMergerBase<TBuilder, T, TKey>
    {
        private Func<T, T> _mapAddCallback = x => x;
        private Action<T, T> _updateCallback = (x, y) => { };
        private Func<T, bool> _addingCallback = x => true;
        private Func<T, bool> _deletingCallback = x => true;
        
        public TBuilder MapAdd(Func<T,T> mapAddCallback)
        {
            _mapAddCallback = mapAddCallback ?? (x => x);
            return (TBuilder)this;
        }

        public TBuilder Update(Action<T, T> updateCallback)
        {
            _updateCallback = updateCallback ?? ((x, y) => { });
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
            if (addingCallback != null)
            {
                _addingCallback = addingCallback;
            }
            
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
            if (deletingCallback != null)
            {
                _deletingCallback = deletingCallback;
            }
            
            return (TBuilder)this;
        }
        
        public void MergeInto(ICollection<T> destCollection)
        {
            _source.MergeInto(destCollection, _getKey, _mapAddCallback, _updateCallback, _addingCallback, _deletingCallback);
        }
    }
    
    public class InPlaceMerger<T, TKey> : InPlaceMergerBase<InPlaceMerger<T, TKey>, T, TKey>
    { }

    public class InPlaceMerger<T> : InPlaceMergerBase<InPlaceMerger<T>, T, object>
    {
        public InPlaceMerger()
        {
            WithKey(item => item);
        }
    }
}
