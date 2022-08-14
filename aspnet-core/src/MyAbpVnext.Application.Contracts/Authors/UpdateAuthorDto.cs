using System;
using System.ComponentModel.DataAnnotations;

namespace MyAbpVnext.Authors
{
    /// <summary>
    /// 我们可以在创建和更新操作间分享 (重用) 相同的DTO. 虽然可以这么做, 但我们推荐为这些操作创建不同的DTOs,
    /// 因为我们发现随着时间的推移, 它们通常会变得有差异. 所以, 与紧耦合相比, 代码重复也是合理的.
    /// </summary>
    public class UpdateAuthorDto
    {
        [Required]
        [StringLength(AuthorConsts.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        public string ShortBio { get; set; }
    }
}