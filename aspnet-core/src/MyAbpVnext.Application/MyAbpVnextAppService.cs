using System;
using System.Collections.Generic;
using System.Text;
using MyAbpVnext.Localization;
using Volo.Abp.Application.Services;

namespace MyAbpVnext;

/* Inherit your application services from this class.
 */
public abstract class MyAbpVnextAppService : ApplicationService
{
    protected MyAbpVnextAppService()
    {
        LocalizationResource = typeof(MyAbpVnextResource);
    }
}
