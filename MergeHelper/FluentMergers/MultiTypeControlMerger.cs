using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MergeHelper
{
    public abstract class ControlMergerBase<TBuilder, TSource, TDest, TKey> : MasterMergerBase<TBuilder, TSource, TDest, TKey>
        where TBuilder : ControlMergerBase<TBuilder, TSource, TDest, TKey>
    {
        private Action<TDest> _deleteCallback = x => { };
        private Action<TSource> _addCallback = x => { };
        private Action<TSource, TDest> _updateCallback = (x, y) => { };
        
        public TBuilder Add(Action<TSource> addCallback)
        {
            _addCallback = addCallback ?? (x => { });
            return (TBuilder)this;
        }

        public TBuilder Update(Action<TSource, TDest> updateCallback)
        {
            _updateCallback = updateCallback ?? ((x, y) => { });
            return (TBuilder)this;
        }

        public TBuilder Delete(Action<TDest> deleteCallback)
        {
            _deleteCallback = deleteCallback ?? (x => { });
            return (TBuilder)this;
        }

        public void Execute(IEnumerable<TDest> destSeq)
        {
            _source.ControlMerge(destSeq, _getSourceKey, _getDestKey, _addCallback, _updateCallback, _deleteCallback);
        }
        
        public void ExecuteParallel(IEnumerable<TDest> destSeq, ParallelOptions options = null)
        {
            _source.ControlMergeParallel(options ?? new ParallelOptions(), destSeq, _getSourceKey, _getDestKey, _addCallback, _updateCallback, _deleteCallback);
        }
    }
    
    public class ControlMerger<TSource, TDest, TKey> : ControlMergerBase<ControlMerger<TSource, TDest, TKey>, TSource, TDest, TKey>
    { }
}
