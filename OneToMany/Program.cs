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


                db.ProductType.Add(type);//添加父类


                db.Product.Add(new Product()//添加子类
                {
                    Name = "百事可乐",
                    Price = 6,
                    IsHot = true,
                    AddTime = DateTime.Now,
                    proType = type
                });


                db.SaveChanges();

            }



            using (MasContext db = new MasContext())
            {
                //遍历子类
                foreach (var item in db.Product)
                {
                    //通过子类的属性，直接访问父类

                    //启用了延迟加载,访问的时候才发送sql语句，进行查询数据。
                    Console.WriteLine(item.proType.Name + "的子类是" + item.Name);

                    /*
                     
                     
                     生成的SQL语句
                     
                     exec sp_executesql N'SELECT 
                    [Extent2].[ID] AS [ID], 
                    [Extent2].[Name] AS [Name], 
                    [Extent2].[AddTime] AS [AddTime], 
                    [Extent2].[Rand] AS [Rand]
                    FROM  [dbo].[Products] AS [Extent1]
                    INNER JOIN [dbo].[ProductTypes] AS [Extent2] ON [Extent1].[proType_ID] = [Extent2].[ID]
                    WHERE ([Extent1].[proType_ID] IS NOT NULL) AND ([Extent1].[ID] = @EntityKeyValue1)',N'@EntityKeyValue1 int',@EntityKeyValue1=1
                     
                     
                     
                     */
                }


                //遍历父类
                foreach (var item in db.ProductType)
                {
                    //通过父类的属性访问子类
                    //启用了延迟加载,访问的时候才发送sql语句，进行查询数据。
                    foreach (var subItem in item.Products)
                    {
                        Console.WriteLine(subItem.Name + "的父类是" + item.Name);


                        /*
                         
                        生成的SQL语句
                         
                        exec sp_executesql N'SELECT 
                        [Extent1].[ID] AS [ID], 
                        [Extent1].[Name] AS [Name], 
                        [Extent1].[AddTime] AS [AddTime], 
                        [Extent1].[Price] AS [Price], 
                        [Extent1].[IsHot] AS [IsHot], 
                        [Extent1].[proType_ID] AS [proType_ID]
                        FROM [dbo].[Products] AS [Extent1]
                        WHERE ([Extent1].[proType_ID] IS NOT NULL) AND ([Extent1].[proType_ID] = @EntityKeyValue1)',N'@EntityKeyValue1 int',@EntityKeyValue1=1
                         
                         
                         
                         
                         
                         
                         
                         */
                    }
                }

            }

        }
    }
}
