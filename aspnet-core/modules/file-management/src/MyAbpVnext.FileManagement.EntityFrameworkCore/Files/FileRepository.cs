using Microsoft.EntityFrameworkCore;
using MyAbpVnext.FileManagement.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace MyAbpVnext.FileManagement.Files
{
    /// <summary>
    /// ABP为每个聚合根或实体提供了 默认的通用(泛型)仓储 ，其中包含了标准的CRUD操作，
    /// 注入IRepository<TEntity, TKey>即可使用。通常来说默认仓储就够用了，有特殊需求时也可以自定义仓储。
    /// 定义仓储接口
    /// </summary>
    public class FileRepository : EfCoreRepository<IFileManagementDbContext, File, Guid>, IFileRepository
    {
        public FileRepository(IDbContextProvider<IFileManagementDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<File> FindByBlobNameAsync(string blobName)
        {
            Check.NotNullOrWhiteSpace(blobName, nameof(blobName));
            var dbset = await GetDbSetAsync();
            return await dbset.FirstOrDefaultAsync(p => p.BlobName == blobName);
        }
    }
}