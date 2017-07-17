using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEF
{
    class Program
    {
        static void Main(string[] args)
        {

            SetInitializer();

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
        }

        /// <summary>
        /// 查询记录——YCSelect
        /// </summary>
        public static void YCSelect()
        {
            //延迟查询
            #region 2.0 查询记录

            using (MasDBContext db = new MasDBContext())
            {
                var donators = db.Donators;

                //只有当LINQ的查询结果被访问或者枚举时才会将查询命令发送到数据库。
                //EF是基于Dbset实现的IQueryable接口来处理延迟查询的。

                Console.WriteLine("Id\t\t姓名\t\t金额\t\t赞助日期");
                foreach (var donator in donators)
                {
                    Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}", donator.DonatorId, donator.Name, donator.Amount, donator.DonateDate.ToShortDateString());
                }
            }

            #endregion

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

                db.Donators.AddRange(donators);
                db.SaveChanges();

                //方法将更改提交到数据库，
                //该方法是以单事务执行的。最终，所有的数据库更改都会以单个工作单元持久化。
                //既然是事务的，那么这就允许将批量相关的更改作为单个操作提交，这样就保证了事务一致性和数据完整性。

            }

            Console.Write("DB has Created!");//提示DB创建成功
            Console.Read();
        }






        /// <summary>
        /// 更新记录——Update
        /// </summary>
        public static void Update()
        {

            using (MasDBContext db = new MasDBContext())
            {

                #region 3.0 更新记录

                var donators = db.Donators;
                if (donators.Any())
                {
                    var toBeUpdatedDonator = donators.First(d => d.Name == "醉千秋");
                    toBeUpdatedDonator.Name = "醉、千秋";
                    db.SaveChanges();
                }

                #endregion
            }

        }



        /// <summary>
        /// 删除记录——Delete
        /// </summary>

        public static void Delete()
        {


            using (MasDBContext db = new MasDBContext())
            {

                #region 4.0 删除记录

                var toBeDeletedDonator = db.Donators.Single(d => d.Name == "待打赏");//根据Name找到要删除的测试数据
                if (toBeDeletedDonator != null)
                {
                    db.Donators.Remove(toBeDeletedDonator);//如果满足条件，就将该对象使用Remove方法标记为Deleted
                    db.SaveChanges();//最后持久化到数据库
                }

                #endregion

            }

        }
    }
}
