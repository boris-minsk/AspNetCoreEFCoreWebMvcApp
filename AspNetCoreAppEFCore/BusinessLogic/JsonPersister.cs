using AspNetCoreAppEFCore.Models;
using Newtonsoft.Json;

namespace AspNetCoreAppEFCore.BusinessLogic
{
    public class JsonPersister : IJsonPersister
    {
        public bool Save(DataModel data)
        {
            JsonConvert.SerializeObject(data);
            return true;
        }
    }
}
