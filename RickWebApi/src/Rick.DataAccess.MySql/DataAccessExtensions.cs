using Microsoft.Extensions.DependencyInjection;
using Rick.DataAccess.Abstraction;
using Rick.DataAccess.Abstraction.Converter;
using Rick.DataAccess.Core.Converter;
using Rick.DataAccess.MySql.Core;
using Rick.DataAccess.MySql.Core.Converter;

namespace Rick.DataAccess.MySql
{
    public static class DataAccessExtensions
    {
        public static IServiceCollection UseDataAccess(this IServiceCollection service)
        {
            return service.AddSingleton<IDbFuncNameConverter, DbFuncNameConverter>()
                .AddSingleton<IDbTypeConverter, DbTypeConverter>()
                .AddSingleton<IScalarConverter, ScalarConverter>()
                .AddSingleton<IEntityConverter, EntityConverter>()
                .AddSingleton<IParamConverter, MySqlParamConverter>()
                .AddTransient<IDataCommand, MySqlDataCommand>();
        }
    }
}