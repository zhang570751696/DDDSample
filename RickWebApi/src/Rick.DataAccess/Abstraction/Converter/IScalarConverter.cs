using System.Data.Common;

namespace Rick.DataAccess.Abstraction.Converter
{
    public interface IScalarConverter
    {
        dynamic Convert<T>(DbDataReader reader);
    }
}