using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToOne
{
    /// <summary>
    /// 映射到数据库中的表名
    /// </summary>
    [Table("Demo")]
    public class DemoAttribute
    {
        /*
                    数据注解
         * 
         * 
         * 
         * 
         * 
         * 
                Table：指定该类要映射到数据库中的表名
                Column：指定类的属性要映射到数据表中的列名
                Key：指定该属性是否以主键对待
                TimeStamp：将该属性标记为数据库中的时间戳列
                ForeignKey：指定一个导航属性的外键属性
                NotMapped：指定该属性不应该映射到数据库中的任何列
                DatabaseGenerated：指定属性应该映射到数据表中计算的列。也可以用于映射到自动增长的数据库表。
                ConcurrencyCheck   标编辑或删除实体时，标记用于在数据库中进行并发检查的一个或多个属性
                InverseProperty---当两个类之间有多个关系时使用。
                ComplexType---将类标记为EF中的复杂类型 
                Index---创建指定列的索引（EF 6.1+） IsClustered 聚簇索引 IsUnique 唯一索引
                Required---必填
                MinLength---最小长度
                MaxLength---最大长度，也是设置数据库列的最大长度
                StringLength---字符串长度
         * 
         */



        /*
        
         组合主键
         [Key]
         [Column(Order=1)]
         public int StudentKey1 { get; set; }

         [Key]
         [Column(Order=2)]
         public int StudentKey2 { get; set; }
         * 
         */

        [Key]//主键 默认设置为自动增长   默认为 "Id" or {Class Name} + "Id"
        //[Index("Demo_Index", IsClustered = true, IsUnique = true)]//创建指定列的索引
        [Column("ID")]//映射到数据表中的列名
        public string ID { get; set; }


        /// <summary>
        /// GUID类型，则要手动的设置自增长
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Key]
        public Guid UserGuid { get; set; }

        [MaxLength(8, ErrorMessage = "名称长度不能大于8")]//最大长度
        [MinLength(2, ErrorMessage = "名称长度不能小于2")]//最小长度
        [StringLength(8, MinimumLength = 2, ErrorMessage = "名称长度不能大于8小于2")]//允许的字符的最小长度和最大长度
        [Required]//值是必需的，不能为空

        //当EF执行更新操作的时候，Code-First将列的值放在where条件语句中，
        //你可以使用这个CurrencyCheck特性，使用已经存在的列做并发检查
        [ConcurrencyCheck]
        [Index("Demo_Name", IsUnique = true)]
        public string Name { get; set; }

        /// <summary>
        /// 指定一个导航属性的外键属性
        /// </summary>
        [ForeignKey("Person")]
        public int PID { get; set; }

        public virtual Person Person { get; set; }

        [NotMapped]//不映射到数据库中的任何列
        public int Age { get; set; }

        /// <summary>
        /// 给列设定的是tiemStamp类型。
        /// 在并发的检查中，Code-First会自动使用这个TimeStamp类型的字段。
        /// </summary>

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
