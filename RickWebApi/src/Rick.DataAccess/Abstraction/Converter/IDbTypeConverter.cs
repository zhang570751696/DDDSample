using System;
using System.Data;

namespace Rick.DataAccess.Abstraction.Converter
{
    public interface IDbTypeConverter
    {
        DbType Convert(Type type);
    }
}