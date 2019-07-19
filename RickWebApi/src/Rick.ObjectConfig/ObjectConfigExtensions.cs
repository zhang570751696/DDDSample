using Rick.ObjectConfig.Abstraction;

namespace Rick.ObjectConfig
{
    public static class ObjectConfigExtensions
    {
        public static T Get<T>(this IConfig config, string key)
        {
            return (T)config.GetConfigSource(key)?.GetValue();
        }
    }
}