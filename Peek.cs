using DbPeek.Interface;
using DbPeek.MySQL;
using System.Text;

namespace DbPeek
{
    public class Peek
    {
        private readonly ITablesRepository _tablesRepository;
        private readonly IExecuteCommand _executeCommand;
        private readonly IDataReader _dataReader;

        public Peek(string connectionString)
        {
            _tablesRepository = new TablesRepository(connectionString);
            _executeCommand = new ExecuteCommand(connectionString);
            _dataReader = new DataReader(connectionString);
        }

        public string TableNames(string tableSchema) 
        {
            var sb = new StringBuilder();
            var dbModels = _tablesRepository.SelectList(tableSchema);
            
            sb.Append("<table border=\"1\">");
            foreach (var dbModel in dbModels)
            {
                sb.Append("<tr>");
                sb.AppendFormat("<td>{0}</td>", dbModel.TableName);
                sb.Append("</tr>");
            }
            sb.Append("</table>");

            return sb.ToString();
        }

        public void ExecuteCommand(string sql)
        {
            _executeCommand.Execute(sql);
        }

        public string DataRead(string table)
        {
            var sb = new StringBuilder();
            var listOfLists = _dataReader.Read(table);

            sb.Append("<table border=\"1\">");
            foreach (var list in listOfLists)
            {
                sb.Append("<tr>");
                foreach (var record in list)
                {
                    sb.AppendFormat("<td>{0}</td>", record);
                }
                sb.Append("</tr>");
            }
            sb.Append("</table>");

            return sb.ToString();
        }
    }
}
