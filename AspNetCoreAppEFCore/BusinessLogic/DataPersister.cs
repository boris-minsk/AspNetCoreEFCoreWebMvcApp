using System.Collections.Generic;
using System.Linq;
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

        public void Save(IEnumerable<DataModel> data)
        {
            var dataModels = data as DataModel[] ?? data.ToArray();
            _dbPersister.Save(dataModels);
            _jsonPersister.Save(dataModels);
        }
    }
}
