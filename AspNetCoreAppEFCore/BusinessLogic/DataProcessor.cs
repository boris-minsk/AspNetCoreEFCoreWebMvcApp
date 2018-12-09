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
        private readonly IDataPersister _dataPersister;

        public DataProcessor(IDataReader reader, IDataMapper mapper, IDataPersister dataPersister)
        {
            _reader = reader;
            _mapper = mapper;
            _dataPersister = dataPersister;
        }

        public bool Process(UploadedData data)
        {
            var lines = _reader.ReadLines(data.FilePath).ToArray();

            var models = new List<DataModel>();
            foreach (var line in lines)
            {
                models.Add(_mapper.MapLine(line));
            }

            bool success = true;
            foreach (var model in models)
            {
                if (!_dataPersister.Save(model))
                {
                    success = false;
                }
            }

            return success;
        }
    }
}
