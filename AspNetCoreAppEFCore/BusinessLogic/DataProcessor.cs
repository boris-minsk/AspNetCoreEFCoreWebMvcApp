using System.Collections.Generic;
using System.Linq;
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
                DataModel model = _mapper.MapLine(line);
                model.FileGuid = data.FileId;
                models.Add(model);
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
