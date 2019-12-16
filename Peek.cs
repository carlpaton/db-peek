using DbPeek.Interface;
using DbPeek.MySQL;
using System.Text;

namespace DbPeek
{
    public class Peek
    {
        private ITablesRepository _tablesRepository;

        public Peek(string connectionString)
        {
            _tablesRepository = new TablesRepository(connectionString);
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
    }
}
