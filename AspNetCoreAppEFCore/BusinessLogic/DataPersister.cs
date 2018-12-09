using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreAppEFCore.Models;

namespace AspNetCoreAppEFCore.BusinessLogic
{
    public class DataPersister : IDataPersister
    {
        private readonly IDbPersister _dbPersister;
        private readonly IJsonPersister _jsonPersister;

        public DataPersister(IDbPersister dbPersister, IJsonPersister jsonPersister)
        {
            _dbPersister = dbPersister;
            _jsonPersister = jsonPersister;
        }

        public bool Save(DataModel data)
        {
            return _dbPersister.Save(data) && _jsonPersister.Save(data);
        }
    }
}
