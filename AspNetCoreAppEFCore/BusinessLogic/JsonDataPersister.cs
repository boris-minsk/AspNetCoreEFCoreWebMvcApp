using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreAppEFCore.Models;

namespace AspNetCoreAppEFCore.BusinessLogic
{
    public class JsonDataPersister : IDataPersister
    {
        public void Persist(DataModel data)
        {
            //string result= JsonConvert.SerializeObject(data);
        }
    }
}
