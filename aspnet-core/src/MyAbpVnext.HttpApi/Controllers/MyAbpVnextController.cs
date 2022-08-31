using MyAbpVnext.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Users;

namespace MyAbpVnext.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class MyAbpVnextController : AbpControllerBase
{
    protected MyAbpVnextController(ICurrentUser _currentUser, ICurrentTenant _currentTenant)
    {
        LocalizationResource = typeof(MyAbpVnextResource);

    }
}
