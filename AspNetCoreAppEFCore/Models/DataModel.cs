using System;

namespace AspNetCoreAppEFCore.Models
{
    public class DataModel
    {
        public string Key { get; set; }
        public int ArticleCode { get; set; }
        public string ColorCode { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string DiscountPrice { get; set; }
        public string DeliveredIn { get; set; }
        public string Q1 { get; set; }
        public int Size { get; set; }
        public string Color { get; set; }
        public Guid FileId { get; set; }
        public File File { get; set; }
    }
}
