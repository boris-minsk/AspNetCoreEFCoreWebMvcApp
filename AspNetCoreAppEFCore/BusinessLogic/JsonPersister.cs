using System.Collections.Generic;
using System.IO;
using AspNetCoreAppEFCore.Models;
using Newtonsoft.Json;

namespace AspNetCoreAppEFCore.BusinessLogic
{
    public class JsonPersister : IJsonPersister
    {
        public void Save(IEnumerable<DataModel> data)
        {
            var filePath = Directory.GetCurrentDirectory() + @"\UploadedFiles";
            Directory.CreateDirectory(filePath);
            var path = filePath + @"\" + "test.json";
            
            if (!File.Exists(path))
            {
                using (File.CreateText(path)) { }
            }

            using (StreamWriter sw = File.AppendText(path))
            {
                foreach (var model in data)
                {
                    sw.Write(JsonConvert.SerializeObject(model));
                }
            }
        }
    }
}
