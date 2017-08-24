using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToMany
{
    class Program
    {


        /*
         
         
         * 表A（一）与表B（多）（我们现在希望，表A中的一条记录对应表B中的多条记录）之间要是有关系，就必须要有外键。
         * 把表A的主键添加到表B里面，充当表B的外键。一对多的实现：在多的一方的表里面，添加外键。
         
         */


        static void Main(string[] args)
        {
            using (MasContext db = new MasContext())
            {

                var type = new ProductType()
                {
                    Name = "饮料",
                    Rand = 1.2M,
                    AddTime = DateTime.Now
                };

                db.ProductType.Add(type);

                db.Product.Add(new Product()
                {
                    Name = "百事可乐",
                    Price = 6,
                    IsHot = true,
                    AddTime = DateTime.Now,
                    proType = type
                });


                db.SaveChanges();

            }
        }
    }
}
