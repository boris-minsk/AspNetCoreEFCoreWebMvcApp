using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreAppEFCore.Models;
using Newtonsoft.Json;

namespace AspNetCoreAppEFCore.BusinessLogic
{
    public class JsonPersister : IJsonPersister
    {
        public bool Save(DataModel data)
        {
            //return JsonConvert.SerializeObject(data);
            return true;
        }
    }
}
