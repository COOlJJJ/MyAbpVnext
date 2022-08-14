using System;
using System.ComponentModel.DataAnnotations;

namespace MyAbpVnext.Books
{
    /// <summary>
    /// 这个DTO类被用于在创建或更新书籍的时候从用户界面获取图书信息.
    ///它定义了数据注释特性(如[Required])来定义属性的验证规则
    /// </summary>
    public class CreateUpdateBookDto
    {
        public Guid AuthorId { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [Required]
        public BookType Type { get; set; } = BookType.Undefined;

        [Required]
        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; } = DateTime.Now;

        [Required]
        public float Price { get; set; }
    }
}
