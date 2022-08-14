using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;

namespace MyAbpVnext
{
    [RemoteService(IsEnabled = false)] //or simply [RemoteService(false)]
    public class PersonAppService : ApplicationService
    {

    }
}
