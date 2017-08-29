using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToMany
{
    /// <summary>
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
        /// </summary>
        public virtual ICollection<Product> Products { get; set; }
    }
}
