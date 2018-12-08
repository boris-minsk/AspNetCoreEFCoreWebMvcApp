using System;
using System.Collections.Generic;

namespace AspNetCoreAppEFCore.Models
{
    public class File
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public DateTime Timestamp { get; set; }
        public string Path { get; set; }

        public ICollection<DataModel> DataModels { get; set; }
    }
}
