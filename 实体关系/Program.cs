using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 实体关系
{
    class Program
    {
        static void Main(string[] args)
        {


            /*

                一对多关系
                一对一关系
                多对多关系
             * 
             * 
             * 
             * 首先要明确关系的概念。关系就是定义两个或多个对象之间是如何关联的。
             * 它是由关系两端的多样性值识别的，比如，一对多意味着在关系的一端，只有一个实体，
             * 我们有时称为父母；在关系的另一端，可能有多个实体，有时称为孩子。
             * EF API将那些端分别称为主体和依赖。一对多关系也叫做一或零对多（One-or-Zero-to-Many）,
             * 这意味着一个孩子可能有或可能没有父母。一对一关系也稍微有些变化，就是关系的两端都是可选的。
             * 
             * 
         
             */

            OneToMore();

        }

        private static void OneToMore()
        {

            #region 6.0 一对多关系

            using (MasDBContext db = new MasDBContext())
            {


                var donator = new Donator
                {
                    Amount = 6,
                    Name = "键盘里的鼠标",
                    DonateDate = DateTime.Parse("2016-4-13"),
                };
                donator.PayWays.Add(new PayWay { Name = "支付宝" });
                donator.PayWays.Add(new PayWay { Name = "微信" });

                db.Donators.Add(donator);
                db.SaveChanges();

            }

            #endregion
        }
    }
}
