using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MergeHelper
{
    public abstract class ControlMergerBase<TBuilder, T, TKey> : MasterMergerBase<TBuilder, T, TKey>
        where TBuilder : ControlMergerBase<TBuilder, T, TKey>
    {
        private Action<T> _deleteCallback = x => { };
        private Action<T> _addCallback = x => { };
        private Action<T, T> _updateCallback = (x, y) => { };

        public TBuilder Add(Action<T> addCallback)
        {
            _addCallback = addCallback ?? (x => { });
            return (TBuilder)this;
        }

        public TBuilder Update(Action<T, T> updateCallback)
        {
            _updateCallback = updateCallback ?? ((x, y) => { });
            return (TBuilder)this;
        }

        public TBuilder Delete(Action<T> deleteCallback)
        {
            _deleteCallback = deleteCallback ?? (x => { });
            return (TBuilder)this;
        }

        public void Execute(IEnumerable<T> destSeq)
        {
            _source.ControlMerge(destSeq, _getKey, _addCallback, _updateCallback, _deleteCallback);
        }
        
        public void ExecuteParallel(IEnumerable<T> destSeq, ParallelOptions options = null)
        {
            _source.ControlMergeParallel(options ?? new ParallelOptions(), destSeq, _getKey, _addCallback, _updateCallback, _deleteCallback);
        }
    }

    public class ControlMerger<T, TKey> : ControlMergerBase<ControlMerger<T, TKey>, T, TKey>
    { }

    public class ControlMerger<T> : ControlMergerBase<ControlMerger<T>, T, object>
    {
        public ControlMerger()
        {
            WithKey(item => item);
        }
    }
}
