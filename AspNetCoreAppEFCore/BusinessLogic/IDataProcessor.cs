using AspNetCoreAppEFCore.Models;

namespace AspNetCoreAppEFCore.BusinessLogic
{
    public interface IDataProcessor
    {
        void Process(UploadedData data);
    }
}
