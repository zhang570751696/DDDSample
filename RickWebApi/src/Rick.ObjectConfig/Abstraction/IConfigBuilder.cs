namespace Rick.ObjectConfig.Abstraction
{
    public interface IConfigBuilder
    {
        IConfigBuilder Add(IConfigProvider provider);

        IConfig Build();
    }
}