using System;
using System.Data;
using Rick.DataAccess.Abstraction.Converter;

namespace Rick.DataAccess.Core.Converter
{
    public class EntityConverter : IEntityConverter
    {
        public Func<IDataReader, T> GetConverter<T>(IDataReader reader)
        {
            return EmitEntityConverter<T>.GetConverter(reader);
        }
    }
}