using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToMany
{
    /// <summary>
    /// 主表（主键是子表的外键）
    /// 父类是One,子类是Many 构成了OneToMany  一对多
    /// 如果外键可以为空，0或1对*
    /// </summary>
    public class ProductType
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public DateTime AddTime { get; set; }

        public decimal Rand { get; set; }

        /// <summary>
        /// virtual 延迟加载
        /// 一个分类对应多个产品（一对多的关系）
        /// </summary>
        public virtual ICollection<Product> Products { get; set; }
    }
}
