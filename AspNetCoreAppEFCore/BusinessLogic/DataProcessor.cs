using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreAppEFCore.Models;

namespace AspNetCoreAppEFCore.BusinessLogic
{
    public class DataProcessor : IDataProcessor
    {
        private readonly IDataReader _reader;
        private readonly IDataMapper _mapper;
        private readonly IDataPersister _dbPersister;
        private readonly IDataPersister _jsonPersister;

        public DataProcessor(IDataReader reader, IDataMapper mapper, IDataPersister dbPersister, IDataPersister jsonPersister)
        {
            _reader = reader;
            _mapper = mapper;
            _dbPersister = dbPersister;
            _jsonPersister = jsonPersister;
        }

        public void Process(UploadedData data)
        {

        }
    }
}
