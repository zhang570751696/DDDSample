using Pomelo.Data.MySql;
using System;
using Rick.DataAccess.Abstraction.Converter;
using Rick.DataAccess.Core.Converter;

namespace Rick.DataAccess.MySql.Core.Converter
{
    public class MySqlParamConverter : ParamConverter
    {
        private Type _ParameterType = typeof(MySqlParameter);

        public MySqlParamConverter(IDbTypeConverter dc) : base(dc)
        {
        }

        protected override Type GetParameterType()
        {
            return _ParameterType;
        }
    }
}