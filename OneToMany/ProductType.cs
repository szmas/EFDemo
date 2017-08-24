using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToMany
{
    public class ProductType
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public DateTime AddTime { get; set; }

        public decimal Rand { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
