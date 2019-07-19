using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using Rick.DataAccess.Abstraction;
using Rick.ObjectConfig;
using Rick.ObjectConfig.Abstraction;

namespace Rick.DataAccess.Config
{
    public class DbManager : IDbManager
    {
        public const string DbConfigKey = "DB";
        private IConfig _Config;
        private IServiceProvider _ServiceProvider;

        public Dictionary<string, DbSql> SqlConfigs
        {
            get
            {
                return _Config.Get<DbConfig>(DbConfigKey)?.Sqls;
            }
        }

        public DbManager(IConfig config, IServiceProvider serviceProvider)
        {
            _Config = config;
            _ServiceProvider = serviceProvider;
        }

        public IDataCommand GetCommand(string commandName)
        {
            DbSql sql = null;
            return SqlConfigs != null && SqlConfigs.TryGetValue(commandName, out sql) ? CreateCommand(sql) : null;
        }

        protected IDataCommand CreateCommand(DbSql sql)
        {
            var command = _ServiceProvider.GetService<IDataCommand>();
            command.ConnectionString = sql.ConnectionString;
            command.Text = sql.Text;
            command.Type = sql.Type;
            command.Timeout = sql.Timeout;
            sql.PreParameters?.ForEach(i => command.PreParameters.Add(i.ToDataParameter()));
            return command;
        }
    }
}