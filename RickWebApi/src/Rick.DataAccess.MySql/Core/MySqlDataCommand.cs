using Pomelo.Data.MySql;
using System.Data.Common;
using Rick.DataAccess.Abstraction.Converter;
using Rick.DataAccess.Core;

namespace Rick.DataAccess.MySql.Core
{
    public class MySqlDataCommand : DataCommand
    {
        public MySqlDataCommand(IParamConverter pc, IScalarConverter sc, IEntityConverter ec) : base(pc, sc, ec)
        {
        }

        protected override DbConnection CreateConnection(string connectionString)
        {
            return new MySqlConnection(connectionString);
        }
    }
}