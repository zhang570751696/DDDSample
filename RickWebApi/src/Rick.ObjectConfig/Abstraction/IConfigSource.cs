namespace Rick.ObjectConfig.Abstraction
{
    public interface IConfigSource
    {
        string Key { get; }

        object GetValue();
    }
}