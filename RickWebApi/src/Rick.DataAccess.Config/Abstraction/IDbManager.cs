namespace Rick.DataAccess.Abstraction
{
    public interface IDbManager
    {
        IDataCommand GetCommand(string commandName);
    }
}