using AspNetCoreAppEFCore.Models;

namespace AspNetCoreAppEFCore.BusinessLogic
{
    public interface IDataProcessor
    {
        bool Process(UploadedData data);
    }
}
