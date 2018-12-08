using System;

namespace AspNetCoreAppEFCore.Models
{
    public class UploadedData
    {
        public Guid FileId { get; set; }
        public string FilePath { get; set; }
    }
}