using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToMany
{

    /// <summary>
    /// 子表（外键是主表的主键）
    /// 子类是Many ,父类是One  构成了OneToMany  一对多
    /// 如果外键可以为空，0或1对*
    /// </summary>
    public class Product
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public DateTime AddTime { get; set; }

        public decimal Price { get; set; }

        public bool IsHot { get; set; }


        /// <summary>
        /// 必填，not null
        /// </summary>
        [Required]
        /// <summary>
        /// 自定义外键  proType是导航名称
        /// </summary>
        [ForeignKey("proType")]
        public int TID { get; set; }

        /// <summary>
        /// virtual 延迟加载
        /// 一个产品对应一个分类（多对一的关系）
        /// </summary>
        public virtual ProductType proType { set; get; }
    }
}
