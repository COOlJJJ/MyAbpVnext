using MyAbpVnext.FileManagement.Localization;
using Volo.Abp.Application.Services;

namespace MyAbpVnext.FileManagement;

public abstract class FileManagementAppService : ApplicationService
{
    protected FileManagementAppService()
    {
        LocalizationResource = typeof(FileManagementResource);
        ObjectMapperContext = typeof(FileManagementApplicationModule);
    }
}
