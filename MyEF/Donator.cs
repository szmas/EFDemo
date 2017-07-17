using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEF
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


        [Key]
        [Column("Id")]
        public int DonatorId { get; set; }
        [StringLength(10, MinimumLength = 2)]
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime DonateDate { get; set; }
    }
}
