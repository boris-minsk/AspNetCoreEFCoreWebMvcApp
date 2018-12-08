using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreAppEFCore.BusinessLogic
{
    public class DataReader : IDataReader
    {
        public IEnumerable<string> ReadLines(string filePath)
        {
            return new List<string>();
        }
    }
}
