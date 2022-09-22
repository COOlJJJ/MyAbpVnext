using MyAbpVnext.FileManagement.Files;
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
    public class PersonAppService : ApplicationService, IPersonAppService
    {
        readonly IFileAppService _fileAppService;

        public PersonAppService(IFileAppService fileAppService)
        {
            _fileAppService = fileAppService;

        }


        public string Test()
        {
            #region For Test Api Client
            var result = _fileAppService.FindByBlobNameAsync("e212e607fcc74347bfc989424d80a164").GetAwaiter().GetResult();
            Console.WriteLine(result);
            return "200";
            #endregion
        }
    }
}
