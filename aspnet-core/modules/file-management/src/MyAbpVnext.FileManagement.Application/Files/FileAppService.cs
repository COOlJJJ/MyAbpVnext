using Microsoft.AspNetCore.Authorization;
using MyAbpVnext.FileManagement.Permissions;
using MyAbpVnext.FileManagement.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Settings;
using Volo.Abp.Validation;

namespace MyAbpVnext.FileManagement.Files
{
    /// <summary>
    /// https://www.cnblogs.com/xhznl/p/13723906.html
    /// 参考xhznl的添加文件管理模块
    /// 初步体验模块化开发
    /// </summary>
    public class FileAppService : FileManagementAppService, IFileAppService
    {
        protected IFileManager FileManager { get; }

        public FileAppService(IFileManager fileManager)
        {
            FileManager = fileManager;
        }

        public virtual async Task<FileDto> FindByBlobNameAsync(string blobName)
        {
            Check.NotNullOrWhiteSpace(blobName, nameof(blobName));

            var file = await FileManager.FindByBlobNameAsync(blobName);
            var bytes = await FileManager.GetBlobAsync(blobName);

            return new FileDto
            {
                Bytes = bytes,
                FileName = file.FileName
            };
        }

        /// <summary>
        /// 在微服务架构下 我们的Action方法不做鉴权 这部分都放入网关中
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public virtual async Task<string> CreateAsync(FileDto input)
        {
            await CheckFile(input);

            var file = await FileManager.CreateAsync(input.FileName, input.Bytes);

            return file.BlobName;
        }

        protected virtual async Task CheckFile(FileDto input)
        {
            if (input.Bytes.IsNullOrEmpty())
            {
                throw new AbpValidationException("Bytes can not be null or empty!",
                    new List<ValidationResult>
                    {
                        new ValidationResult("Bytes can not be null or empty!", new[] {"Bytes"})
                    });
            }

            //这边使用SettingProvider 注入失败 先注释继续往下测试= =
            //var allowedMaxFileSize = await SettingProvider.GetAsync<int>(FileManagementSettings.AllowedMaxFileSize);//kb
            //var allowedUploadFormats = (await SettingProvider.GetOrNullAsync(FileManagementSettings.AllowedUploadFormats))
            //    ?.Split(",", StringSplitOptions.RemoveEmptyEntries);

            //if (input.Bytes.Length > allowedMaxFileSize * 1024)
            //{
            //    throw new UserFriendlyException(L["FileManagement.ExceedsTheMaximumSize", allowedMaxFileSize]);
            //}

            //if (allowedUploadFormats == null || !allowedUploadFormats.Contains(Path.GetExtension(input.FileName)))
            //{
            //    throw new UserFriendlyException(L["FileManagement.NotValidFormat"]);
            //}
        }

    }
}