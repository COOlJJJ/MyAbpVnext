using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace MyAbpVnext.Books
{
    /// <summary>
    /// 框架定义应用程序服务的接口不是必需的. 但是,它被建议作为最佳实践.
    /// ICrudAppService定义了常见的CRUD方法:GetAsync,GetListAsync,CreateAsync,UpdateAsync和DeleteAsync. 从这个接口扩展不是必需的,你可以从空的IApplicationService接口继承并手动定义自己的方法(将在下一部分中完成).
    /// ICrudAppService有一些变体, 你可以在每个方法中使用单独的DTO(例如使用不同的DTO进行创建和更新).
    /// </summary>
    public interface IBookAppService :
        ICrudAppService< //Defines CRUD methods
            BookDto, //Used to show books
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateBookDto> //Used to create/update a book
    {
        // ADD the NEW METHOD
        Task<ListResultDto<AuthorLookupDto>> GetAuthorLookupAsync();
    }
}
