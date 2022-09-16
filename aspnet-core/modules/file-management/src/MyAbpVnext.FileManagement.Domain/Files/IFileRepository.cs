using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace MyAbpVnext.FileManagement.Files
{
    public interface IFileRepository : IRepository<File, Guid>
    {
        Task<File> FindByBlobNameAsync(string blobName);
    }
}