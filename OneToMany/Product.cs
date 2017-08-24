using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToMany
{
    public class Product
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public DateTime AddTime { get; set; }

        public decimal Price { get; set; }

        public bool IsHot { get; set; }

        public virtual ProductType proType { set; get; }
    }
}
