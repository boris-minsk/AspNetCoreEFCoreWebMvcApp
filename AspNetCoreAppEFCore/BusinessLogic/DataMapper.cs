using AspNetCoreAppEFCore.Models;

namespace AspNetCoreAppEFCore.BusinessLogic
{
    public class DataMapper : IDataMapper
    {
        public DataModel MapLine(string line)
        {
            string[] tokens = line.Split(',');
            return new DataModel
            {
                Key = tokens[0],
                ArticleCode = tokens[1],
                ColorCode = tokens[2],
                Description = tokens[3],
                Price = tokens[4],
                DiscountPrice = tokens[5],
                DeliveredIn = tokens[6],
                Q1 = tokens[7],
                Size = tokens[8],
                Color = tokens[9],
            };
        }
    }
}
