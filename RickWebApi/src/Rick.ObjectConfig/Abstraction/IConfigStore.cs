using Microsoft.Extensions.FileProviders;

namespace Rick.ObjectConfig.Abstraction
{
    public interface IConfigStore : IConfig
    {
        IFileProvider FileProvider { get; }

        bool Update(IConfigSource source);
    }
}