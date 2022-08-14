using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace MyAbpVnext.Books
{
    /// <summary>
    /// ABP为实体提供了两个基本的基类: AggregateRoot和Entity. Aggregate Root是领域驱动设计 概念之一. 可以视为直接查询和处理的根实体.
    ///Book实体继承了AuditedAggregateRoot,AuditedAggregateRoot类在AggregateRoot类的基础上添加了一些基础审计属性(例如CreationTime, CreatorId, LastModificationTime 等). ABP框架自动为你管理这些属性.
    ///Guid是Book实体的主键类型.
    /// </summary>
    public class Book : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }

        public BookType Type { get; set; }

        public DateTime PublishDate { get; set; }

        public float Price { get; set; }
        /// <summary>
        /// 在本章中, 我们选择不在 Book 类中加入 Author 实体的 导航属性 (例如 public Author Author { get; set; }). 
        /// 这是为了遵循 DDD 最佳实践 (规则: 仅通过id引用其它聚合对象). 但是, 你自己可以添加这样的导航属性, 
        /// 并为EF Core配置它. 这样, 你在获取图书和它们的作者时就不需要写join查询了(如同下面我们做的一样), 这会使代码更简洁一些.
        /// </summary>
        public Guid AuthorId { get; set; }
    }
}
