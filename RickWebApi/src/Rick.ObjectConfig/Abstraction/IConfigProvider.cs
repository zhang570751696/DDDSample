using Rick.ObjectConfig.Abstraction;

namespace Rick.ObjectConfig.Abstraction
{
    public interface IConfigProvider
    {
        void SetConfig(IConfigStore config);
    }
}