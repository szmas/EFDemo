using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEF
{
    class Program
    {
        static void Main(string[] args)
        {

            CRUD.Run();

        }

        /// <summary>
        /// 初始化器（Initializer）
        /// </summary>
        private static void SetInitializer()
        {
            //使用该初始化器
            Database.SetInitializer(new Initializer());

            //指如果模型改变了（包括模型类的更改以及上下文中集合属性的添加和移除）就销毁之前的数据库再创建数据库
            using (MasDBContext db = new MasDBContext())
            {
                db.PayWays.ToList();
            }
        }




        /// <summary>
        /// 创建数据库上下文
        /// </summary>
        public static void CreateDB()
        {
            using (var db = new MasDBContext())
            {

                //db.Database.CreateIfNotExists();//如果数据库不存在时则创建
                db.Donators.Add(new Donator() { Name = "mas", Amount = 10000, DonateDate = DateTime.Now });
                db.SaveChanges();//自动创建数据库
                //这是通过检测上下文中所有的对象的状态来完成的。所有的对象都驻留在上下文类
                //Deleted，Added，Modified和Unchanged

            }

            //将DbContext转换成ObjectContext
            using (var db = new MasDBContext())
            {
                var objectContext = (db as System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext;
            }
        }




        /// <summary>
        /// 创建记录——Create
        /// </summary>
        private static void Insert()
        {
            using (var db = new MasDBContext())
            {


                var donators = new List<Donator>
                {
                    new Donator
                    {
                      Name   = "陈志康",
                      Amount = 50,
                      DonateDate = new DateTime(2016, 4, 7)
                    },
                    new Donator
                    {
                        Name = "海风",
                        Amount = 5,
                        DonateDate = new DateTime(2016, 4, 8)
                    },
                    new Donator
                    {
                        Name = "醉千秋",
                        Amount = 18.8m,
                        //DonateDate = new DateTime(2016, 4, 15)   一条语句有问题，所有语句都回滚
                    }
                };

                db.Donators.AddRange(donators);//批量数据插入
                db.SaveChanges();

                //方法将更改提交到数据库，
                //该方法是以单事务执行的。最终，所有的数据库更改都会以单个工作单元持久化。
                //既然是事务的，那么这就允许将批量相关的更改作为单个操作提交，这样就保证了事务一致性和数据完整性。

            }



            using (var db = new MasDBContext())
            {
                var donators = new List<Donator>
                {
                    new Donator
                    {
                      Name   = "陈志康",
                      Amount = 50,
                      DonateDate = new DateTime(2016, 4, 7)
                    },
                    new Donator
                    {
                        Name = "海风",
                        Amount = 5,
                        DonateDate = new DateTime(2016, 4, 8)
                    },
                    new Donator
                    {
                        Name = "醉千秋",
                        Amount = 18.8m,
                        //DonateDate = new DateTime(2016, 4, 15)   一条语句有问题，所有语句都回滚
                    }
                };

                //将donators添加到DbEntityEntry中，并将State状态设置为 Added
                db.Entry(donators).State = EntityState.Added;

                db.SaveChanges();

            }





            Console.Write("DB has Created!");//提示DB创建成功
            Console.Read();
        }



        /// <summary>
        /// 异步操作
        /// </summary>
        private async static void InsertAsync()
        {

            using (var db = new MasDBContext())
            {
                var donators = new List<Donator>
                {
                    new Donator
                    {
                      Name   = "陈志康",
                      Amount = 50,
                      DonateDate = new DateTime(2016, 4, 7)
                    },
                    new Donator
                    {
                        Name = "海风",
                        Amount = 5,
                        DonateDate = new DateTime(2016, 4, 8)
                    },
                    new Donator
                    {
                        Name = "醉千秋",
                        Amount = 18.8m,
                        //DonateDate = new DateTime(2016, 4, 15)   一条语句有问题，所有语句都回滚
                    }
                };

                //将donators添加到DbEntityEntry中，并将State状态设置为 Added
                db.Entry(donators).State = EntityState.Added;

                int result = await db.SaveChangesAsync();//支持异步操作
            }
        }








    }
}
