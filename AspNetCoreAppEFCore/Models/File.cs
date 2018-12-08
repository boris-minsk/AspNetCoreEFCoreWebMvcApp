using System;
using System.Collections.Generic;

namespace AspNetCoreAppEFCore.Models
{
    public class File
    {
        public Guid Id { get; set; }
        public string Path { get; set; }

        public ICollection<DataModel> DataModels { get; set; }
    }
}
