using DbPeek.Interface;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace DbPeek.MySQL
{
    public class DataReader : IDataReader
    {
        private readonly string _connectionString;

        public DataReader(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<List<object>> Read(string table) 
        {
            var dataList = new List<List<object>>();
            using (var connection = new MySqlConnection(_connectionString)) 
            {
                connection.Open();
                var sql = $"SELECT * FROM {table};";

                using(var command = new MySqlCommand(sql, connection)) 
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read()) 
                        {
                            var row = new List<object>();
                            for (int i = 0; i < reader.VisibleFieldCount ; i++)
                            {
                                row.Add(reader[i]);
                            }
                            dataList.Add(row);
                        }
                    }
                }

                connection.Close();
            }
            return dataList;
        }
    }
}
