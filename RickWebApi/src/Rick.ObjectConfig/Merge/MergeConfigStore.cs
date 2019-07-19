using Rick.ObjectConfig.Abstraction;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Rick.ObjectConfig.Merge
{
    public class MergeConfigStore : IConfig
    {
        private IReadOnlyCollection<IConfig> _Configs;
        private Func<IEnumerable<object>, object> _Aggregate;
        public MergeConfigStore(IReadOnlyCollection<IConfig> configs, Func<IEnumerable<object>, object> aggregate)
        {
            _Configs = configs;
            _Aggregate = aggregate;
        }

        public IConfigSource GetConfigSource(string key)
        {
            return new ConfigSource(key, () => _Aggregate(_Configs
                .Select(i => i.GetConfigSource(key))
                .Where(i => i != null)
                .Select(i => i.GetValue())));
        }
    }
}