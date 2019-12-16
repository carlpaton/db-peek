using System.Collections.Generic;
using DbPeek.Interface;
using DbPeek.Models;

namespace DbPeek.MySQL
{
    public class TablesRepository : MySQLContext, ITablesRepository
    {
        public TablesRepository(string connectionString) : base(connectionString) 
        {
            
        }

        public List<TablesModel> SelectList(string tableSchema)
        {
            var sql = @"
SELECT table_name 
FROM information_schema.tables 
WHERE table_type = 'base table'
AND table_schema=@tableSchema;";

            return SelectList<TablesModel>(sql, new { tableSchema });
        }
    }
}
