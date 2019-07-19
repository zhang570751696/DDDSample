using System;
using System.Collections.Generic;
using Rick.ObjectConfig.Abstraction;

namespace Rick.ObjectConfig.Merge
{
    public class MergeConfigBuilder
    {
        protected List<IConfig> _Providers = new List<IConfig>();
        protected Func<IEnumerable<object>, object> _Aggregate;

        public MergeConfigBuilder(Func<IEnumerable<object>, object> aggregate)
        {
            _Aggregate = aggregate;
        }

        public MergeConfigBuilder Add(IConfig provider)
        {
            _Providers.Add(provider);
            return this;
        }

        public IConfig Build()
        {
            return new MergeConfigStore(_Providers, _Aggregate);
        }
    }
}