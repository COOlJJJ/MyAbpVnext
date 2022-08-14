using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace MyAbpVnext.Books
{
    /// <summary>
    /// DTO类被用来在 表示层 和 应用层 传递数据
    /// 为了在用户界面上展示书籍信息,BookDto被用来将书籍数据传递到表示层.
    /// BookDto继承自 AuditedEntityDto<Guid>.与上面定义的 Book 实体一样具有一些审计属性
    /// </summary>
    public class BookDto : AuditedEntityDto<Guid>
    {
        public Guid AuthorId { get; set; }
        public string AuthorName { get; set; }

        public string Name { get; set; }

        public BookType Type { get; set; }

        public DateTime PublishDate { get; set; }

        public float Price { get; set; }
    }
}
