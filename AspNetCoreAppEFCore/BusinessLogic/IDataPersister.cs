using AspNetCoreAppEFCore.Models;

namespace AspNetCoreAppEFCore.BusinessLogic
{
    public interface IDataPersister
    {
        bool Save(DataModel data);
    }
}
