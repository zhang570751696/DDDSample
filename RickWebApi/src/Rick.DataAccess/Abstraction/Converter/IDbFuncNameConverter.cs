using System;

namespace Rick.DataAccess.Abstraction.Converter
{
    public interface IDbFuncNameConverter
    {
        string Convert(Type type);
    }
}