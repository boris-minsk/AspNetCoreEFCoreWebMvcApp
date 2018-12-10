using AspNetCoreAppEFCore.Models;

namespace AspNetCoreAppEFCore.BusinessLogic
{
    public interface IDataMapper
    {
        DataModel MapLine(string line);
    }
}
