using System.Collections.Generic;

namespace DbPeek.Interface
{
    public interface IDataReader
    {
        List<List<object>> Read(string table);
    }
}
