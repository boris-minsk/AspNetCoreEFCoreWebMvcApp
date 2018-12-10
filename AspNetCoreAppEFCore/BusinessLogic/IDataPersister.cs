using System.Collections.Generic;
using AspNetCoreAppEFCore.Models;

namespace AspNetCoreAppEFCore.BusinessLogic
{
    public interface IDataPersister
    {
        void Save(IEnumerable<DataModel> data);
    }
}
