using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyAbpVnext.FileManagement.Permissions;
using Volo.Abp;
using Volo.Abp.Http;

namespace MyAbpVnext.FileManagement.Files
{
    [RemoteService]
    [Route("api/file-management/files")]
    public class FileController : FileManagementController
    {
        protected IFileAppService FileAppService { get; }

        public FileController(IFileAppService fileAppService)
        {
            FileAppService = fileAppService;
        }

        [HttpGet]
        [Route("{blobName}")]
        public virtual async Task<FileResult> GetAsync(string blobName)
        {
            var fileDto = await FileAppService.FindByBlobNameAsync(blobName);
            return File(fileDto.Bytes, MimeTypes.GetByExtension(Path.GetExtension(fileDto.FileName)));
        }

        [HttpPost]
        [Route("upload")]
        public virtual async Task<JsonResult> CreateAsync(IFormFile file)
        {
            if (file == null)
            {
                throw new UserFriendlyException("No file found!");
            }

            var bytes = await file.GetAllBytesAsync();
            var result = await FileAppService.CreateAsync(new FileDto()
            {
                Bytes = bytes,
                FileName = file.FileName
            });
            return new JsonResult(result);

        }

    }
}
