using DbPeek.Models;
using System.Collections.Generic;

namespace DbPeek.Interface
{
    public interface ITablesRepository
    {
        List<TablesModel> SelectList(string tableSchema);
    }
}
