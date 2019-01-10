using System;
using System.Collections.Generic;

namespace MergeHelper
{
    public abstract class MasterMergerBase<TBuilder, TSource, TDest, TKey> 
        where TBuilder : MasterMergerBase<TBuilder, TSource, TDest, TKey>
    {
        internal IEnumerable<TSource> _source = GetEmptySource();
        internal Func<TSource, TKey> _getSourceKey;
        internal Func<TDest, TKey> _getDestKey;
        
        public TBuilder FromSource(IEnumerable<TSource> source)
        {
            _source = source ?? GetEmptySource();
            return (TBuilder)this;
        }

        public TBuilder WithSourceKey(Func<TSource, TKey> getSourceKey)
        {
            _getSourceKey = getSourceKey;
            return (TBuilder)this;
        }

        public TBuilder WithDestKey(Func<TDest, TKey> getDestKey)
        {
            _getDestKey = getDestKey;
            return (TBuilder)this;
        }

        private static IEnumerable<TSource> GetEmptySource()
        {
            yield break;
        }
    }
}
