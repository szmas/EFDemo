using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 实体关系
{
    [Table("Donator")]
    class Donator
    {


        /*
         
         
         
        Table：指定该类要映射到数据库中的表名
        Column：指定类的属性要映射到数据表中的列名
        Key：指定该属性是否以主键对待
        TimeStamp：将该属性标记为数据库中的时间戳列
        ForeignKey：指定一个导航属性的外键属性
        NotMapped：指定该属性不应该映射到数据库中的任何列
        DatabaseGenerated：指定属性应该映射到数据表中计算的列。也可以用于映射到自动增长的数据库表。
         
         
         此外，数据注解也用作验证特性。如果持久化数据时，模型对象的属性值和数据注解所标记的不一致，就会抛异常。
         例如上面的PayWay类的Name属性，ErrorMessage的值就是发生异常时抛出的信息。
         
         
         
         */


        public Donator()
        {
            PayWays = new HashSet<PayWay>();
        }

        [Key]
        [Column("Id")]
        public int DonatorId { get; set; }
        [StringLength(10, MinimumLength = 2)]
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime DonateDate { get; set; }

        public virtual ICollection<PayWay> PayWays { get; set; } //懒加载（lazy loading）
        public int? DonatorTypeId { get; set; }

        public virtual DonatorType DonatorType { get; set; }

        /*
         
         
         该关键字允许我们使用懒加载（lazy loading），也就是说当你尝试访问Donator的PayWays属性时，
         EF会动态地从数据库加载PayWays对象到该集合中。懒加载，顾名思义，
         就是首次不会执行查询来填充PayWays属性，而是在请求它时才会加载数据。
         
         
         
         还有另一加载相关数据的方式叫做预先加载（eager loading）。
         通过预先加载，在访问PayWays属性之前，PayWays就会主动加载。
         
         */
    }
}
