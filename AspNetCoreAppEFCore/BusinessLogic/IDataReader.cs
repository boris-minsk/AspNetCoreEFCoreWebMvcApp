using System.Collections.Generic;

namespace AspNetCoreAppEFCore.BusinessLogic
{
    public interface IDataReader
    {
        IEnumerable<string> ReadLines(string filePath);
        string ReadFile(string filePath);
    }
}
