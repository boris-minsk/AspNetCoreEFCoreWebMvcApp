using System.Collections.Generic;
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

        public void Process(UploadedData data)
        {
            var models = new List<DataModel>();
            var lines = _reader.ReadLines(data.FilePath);

            foreach (var line in lines)
            {
                models.Add(_mapper.MapLine(line));
            }

            _dataPersister.Save(models);
        }
    }
}
