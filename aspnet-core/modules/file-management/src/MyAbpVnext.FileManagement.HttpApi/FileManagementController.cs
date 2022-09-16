using MyAbpVnext.FileManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace MyAbpVnext.FileManagement;

public abstract class FileManagementController : AbpControllerBase
{
    protected FileManagementController()
    {
        LocalizationResource = typeof(FileManagementResource);
    }
}
