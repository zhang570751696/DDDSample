using System.Collections.Generic;

namespace Rick.DataAccess.Abstraction
{
    public interface IConnectionStringProvider
    {
        void Update(Dictionary<string, string> connectionStrings);
    }
}