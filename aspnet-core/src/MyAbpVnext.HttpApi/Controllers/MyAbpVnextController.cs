using MyAbpVnext.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace MyAbpVnext.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class MyAbpVnextController : AbpControllerBase
{
    protected MyAbpVnextController()
    {
        LocalizationResource = typeof(MyAbpVnextResource);
    }
}
