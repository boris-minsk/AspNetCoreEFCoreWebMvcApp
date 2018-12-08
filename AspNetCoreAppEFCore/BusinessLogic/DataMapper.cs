using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreAppEFCore.Models;

namespace AspNetCoreAppEFCore.BusinessLogic
{
    public class DataMapper : IDataMapper
    {
        public DataModel MapLine(string line)
        {
            return new DataModel();
        }
    }
}
