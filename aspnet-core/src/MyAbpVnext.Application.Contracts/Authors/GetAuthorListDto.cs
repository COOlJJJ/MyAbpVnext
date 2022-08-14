using Volo.Abp.Application.Dtos;

namespace MyAbpVnext.Authors
{
    /// <summary>
    /// PagedAndSortedResultRequestDto 具有标准分页和排序属性: int MaxResultCount, int SkipCount 和 string Sorting.
    /// </summary>
    public class GetAuthorListDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}