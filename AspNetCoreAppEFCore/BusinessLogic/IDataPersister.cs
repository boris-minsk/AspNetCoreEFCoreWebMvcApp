using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreAppEFCore.Models;

namespace AspNetCoreAppEFCore.BusinessLogic
{
    public interface IDataPersister
    {
        bool Save(DataModel data);
    }
}
