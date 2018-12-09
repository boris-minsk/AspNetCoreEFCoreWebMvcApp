using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreAppEFCore.Models;

namespace AspNetCoreAppEFCore.BusinessLogic
{
    public class DbPersister : IDbPersister
    {
        public bool Save(DataModel data)
        {
            return true;
        }
    }
}
