using System;
using System.Collections.Generic;

namespace MergeHelper
{
    public abstract class MasterMergerBase<TBuilder, T, TKey> where TBuilder : MasterMergerBase<TBuilder, T, TKey>
    {
        private protected IEnumerable<T> _source = GetEmptySource();
        private protected Func<T, TKey> _getKey;

        public TBuilder WithKey(Func<T, TKey> getKey)
        {
            _getKey = getKey;
            return (TBuilder) this;
        }

        public TBuilder FromSource(IEnumerable<T> source)
        {
            _source = source ?? GetEmptySource();
            return (TBuilder)this;
        }
        
        private static IEnumerable<T> GetEmptySource()
        {
            yield break;
        }
    }
}
