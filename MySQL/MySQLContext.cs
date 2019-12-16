using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DbPeek.MySQL
{
    public class MySQLContext : IDisposable
    {
        private readonly MySqlConnection _dbConn;

        public MySQLContext(string connectionString)
        {
            DefaultTypeMap.MatchNamesWithUnderscores = true;
            _dbConn = new MySqlConnection(connectionString);
        }

        public void Dispose()
        {
            _dbConn.Close();
            _dbConn.Dispose();
        }

        public List<T> SelectList<T>(string sql, object parameters = null)
        {
            using (_dbConn)
            {
                Open();
                return _dbConn.Query<T>(sql, parameters).ToList();
            }
        }

        private void Open()
        {
            if (_dbConn.State == ConnectionState.Closed)
                _dbConn.Open();
        }
    }
}
