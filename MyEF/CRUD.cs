using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace MyEF
{
    public class CRUD
    {


        public static void Run()
        {

            Update();
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
        public static void CreateDBContext()
        {
            //DbContext
            using (var db = new MasDBContext())
            {

                //db.Database.CreateIfNotExists();//如果数据库不存在时则创建
                db.Donators.Add(new Donator() { Name = "mas", Amount = 10000, DonateDate = DateTime.Now });
                db.SaveChanges();//自动创建数据库
                //这是通过检测上下文中所有的对象的状态来完成的。所有的对象都驻留在上下文类
                //Deleted，Added，Modified和Unchanged

            }


            //自定义连接字符串
            using (var db = new MasDBContext("Server=.;Database=CodeFirstAppx;Integrated Security=SSPI;MultipleActiveResultSets=true;"))
            {
                db.Donators.FirstOrDefault();
            }


            //将DbContext转换成ObjectContext
            using (var db = new MasDBContext())
            {
                var objectContext = (db as System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext;
            }
        }




        /// <summary>
        /// 查询记录——YCSelect
        /// </summary>
        static void Select()
        {




            //使用LINQ方法查询
            using (MasDBContext db = new MasDBContext())
            {
                var info = db.Donators.FirstOrDefault(w => w.DonatorId == 1);
            }


            //使用LINQ语法查询
            using (MasDBContext db = new MasDBContext())
            {
                var query = from c in db.Donators
                            where c.DonatorId == 1
                            select c;

                var info = query.FirstOrDefault();

            }





            //使用本地SQL查询关系型数据库
            using (MasDBContext db = new MasDBContext())
            {
                var info = db.Donators.SqlQuery("SELECT [Id] as DonatorId ,[DonatorName] as Name,[Amount],[DonateDate] FROM Donator WHERE Id=" + 1).FirstOrDefault();
            }


            //通过ObjectContext 来创建Entity SQL查询，它是由实体框架的对象服务直接处理的。它返回ObjectQuery而不是IQueryable。
            //using (MasDBContext db = new MasDBContext())
            //{
            //    string sqlstring = "SELECT [Id] as DonatorId,[DonatorName] as Name,[Amount],[DonateDate] FROM [CodeFirstApp].[Donator] WHERE Id =" + 1;
            //    var objectContext = (db as IObjectContextAdapter).ObjectContext;
            //    var info = objectContext.CreateQuery<Donator>(sqlstring).FirstOrDefault();
            //}

        }


        static void YCSelect()
        {

            #region 2.0 延迟查询

            using (MasDBContext db = new MasDBContext())
            {
                var donators = db.Donators;

                //只有当LINQ的查询结果被访问或者枚举时才会将查询命令发送到数据库。
                //EF是基于Dbset实现的IQueryable接口来处理延迟查询的。

                Console.WriteLine("Id\t\t姓名\t\t金额\t\t赞助日期");
                foreach (var donator in donators)
                {
                    Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}", donator.DonatorId, donator.Name, donator.Amount, donator.DonateDate.ToShortDateString());

                    //延迟查询
                    foreach (var sub in donator.PayWays)
                    {
                        Console.WriteLine("{0}\t\t{1}\t\t{2}", sub.Id, sub.Name, sub.donator.Amount);
                    }
                }
            }

            #endregion
        }



        /// <summary>
        /// 创建记录——Create
        /// </summary>
        static void Insert()
        {

            #region 批量新增

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
                        DonateDate = new DateTime(2016, 4, 15)   //一条语句有问题，所有语句都回滚
                    }
                };

                db.Donators.AddRange(donators);//批量数据插入
                db.SaveChanges();//隐式事务，自动提交事务

                //方法将更改提交到数据库，
                //该方法是以单事务执行的。最终，所有的数据库更改都会以单个工作单元持久化。
                //既然是事务的，那么这就允许将批量相关的更改作为单个操作提交，这样就保证了事务一致性和数据完整性。

            }

            #endregion


            #region 批量新增  DbEntityEntry设为Added

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
                       DonateDate = new DateTime(2016, 4, 15)   //一条语句有问题，所有语句都回滚
                    }
                };

                //将donators添加到DbEntityEntry中，并将State状态设置为 Added
                foreach (var item in donators)
                {
                    db.Entry(item).State = EntityState.Added;
                }

                db.SaveChanges();

            }
            #endregion



            Console.Write("DB has Created!");//提示DB创建成功
            Console.Read();
        }





        /// <summary>
        /// 更新记录——Update
        /// </summary>
        static void Update()
        {
            goto GG;

            #region 先查询，后修改

            using (MasDBContext db = new MasDBContext())
            {

                #region 3.0 更新记录 单个值修改
                //先查询出要修改的数据，然后再修改新的值
                var toBeUpdatedDonator = db.Donators.FirstOrDefault(d => d.DonatorId == 1);
                if (toBeUpdatedDonator != null)
                {
                    toBeUpdatedDonator.Name = "醉千秋";
                    toBeUpdatedDonator.DonateDate = DateTime.Now;
                    //db.Entry(toBeUpdatedDonator).State = EntityState.Modified; //全部字段更新
                    db.SaveChanges();
                }

                //sql语句

                /*

               更新了部分字段
                exec sp_executesql N'UPDATE [dbo].[Donator]
                SET [DonatorName] = @0, [DonateDate] = @1
                WHERE ([Id] = @2)
                ',N'@0 nvarchar(10),@1 datetime2(7),@2 int',@0=N'醉千秋',@1='2017-08-28 10:44:02.7261187',@2=3
                 
                 */

                #endregion
            }

            #endregion


            #region 更新记录 单个值修改

            using (MasDBContext db = new MasDBContext())
            {
                Donator entity = new Donator() { DonatorId = 1, Name = "Mas", DonateDate = DateTime.Now };
                //将当前实体用EF进行跟踪
                db.Donators.Attach(entity);
                entity.Name = "Mass";
                db.SaveChanges();

                //sql语句
                /*
                 更新了部分字段

                 exec sp_executesql N'UPDATE [dbo].[Donator]
                SET [DonatorName] = @0
                WHERE ([Id] = @1)
                ',N'@0 nvarchar(10),@1 int',@0=N'Mass',@1=1
                 
                 
                 */


            }

            #endregion


            #region 更新记录 全部值修改

            using (MasDBContext db = new MasDBContext())
            {
                //
                Donator entity = new Donator() { DonatorId = 1 };
                //将状态设置为Modified
                DbEntityEntry entry = db.Entry(entity);
                entry.State = EntityState.Modified;

                db.SaveChanges();

                //sql语句
                /*
                 是更新了全部字段

                 exec sp_executesql N'UPDATE [dbo].[Donator]
                SET [DonatorName] = @0, [Amount] = @1, [DonateDate] = @2
                WHERE ([Id] = @3)
                ',N'@0 nvarchar(10),@1 decimal(18,2),@2 datetime2(7),@3 int',@0=N'Mas',@1=0,@2='2017-08-28 11:07:59.6731249',@3=1
                 
                 
                 */

            }

            #endregion



            #region 更新记录 部分值修改


            using (MasDBContext db = new MasDBContext())
            {
                Donator article = new Donator() { DonatorId = 1, Name = "Mas", DonateDate = DateTime.Now };

                //将当前实体用EF进行跟踪
                db.Donators.Attach(article);
                DbEntityEntry entry = db.Entry(article);

                //部分更新 需要的字段设为为IsModified=true
                entry.Property("Name").IsModified = true;
                entry.Property("DonateDate").IsModified = true;

                db.SaveChanges();


                //sql
                /*
                 
                    是更新了全部字段

                    exec sp_executesql N'UPDATE [dbo].[Donator]
                    SET [DonatorName] = @0, [DonateDate] = @1
                    WHERE ([Id] = @2)
                    ',N'@0 nvarchar(10),@1 datetime2(7),@2 int',@0=N'Mas',@1='2017-08-28 11:26:37.6201252',@2=1
                 
                 
                 */

            }


            #endregion



        GG:

            using (var db = new MasDBContext())
            {
                Donator originalEmployee = new Donator() { DonatorId = 1 };

                db.Donators.Attach(originalEmployee);

                Donator newEmployee = new Donator() { DonatorId = 1, Name = "Mas", DonateDate = DateTime.Now, Amount = 100 };

                db.Entry(originalEmployee).CurrentValues.SetValues(newEmployee);

                db.SaveChanges();



                /*
                 
                 Donator originalEmployee = new Donator() { DonatorId = 1 };
                 Donator newEmployee = new Donator() { DonatorId = 1, Name = "Mas", DonateDate = DateTime.Now, Amount = 100 };
                  
                 
                exec sp_executesql N'UPDATE [dbo].[Donator]
                SET [DonatorName] = @0, [Amount] = @1, [DonateDate] = @2
                WHERE ([Id] = @3)
                ',N'@0 nvarchar(10),@1 decimal(18,2),@2 datetime2(7),@3 int',@0=N'Mas',@1=100.00,@2='2017-08-28 17:50:36.4737045',@3=1
                 
                 
                  
                  
                 Donator originalEmployee = new Donator() { DonatorId = 1, Name = "Mas", };
                 Donator newEmployee = new Donator() { DonatorId = 1, Name = "Mas", DonateDate = DateTime.Now, Amount = 100 };
                 
                  
                  
                    exec sp_executesql N'UPDATE [dbo].[Donator]
                    SET [Amount] = @0, [DonateDate] = @1
                    WHERE ([Id] = @2)
                    ',N'@0 decimal(18,2),@1 datetime2(7),@2 int',@0=100.00,@1='2017-08-28 18:34:34.5027045',@2=1
                 
                 */


            }


            Console.Write("DB has Updated!");//提示DB创建成功
            Console.Read();

        }




        /// <summary>
        /// 删除记录——Delete
        /// </summary>

        static void Delete()
        {

            #region 先查询后删除

            using (MasDBContext db = new MasDBContext())
            {

                #region 4.0 删除记录

                var toBeDeletedDonator = db.Donators.FirstOrDefault(d => d.Name == "待打赏");//根据Name找到要删除的测试数据
                if (toBeDeletedDonator != null)
                {
                    db.Donators.Remove(toBeDeletedDonator);//如果满足条件，就将该对象使用Remove方法标记为Deleted
                    db.SaveChanges();//最后持久化到数据库

                    //db.Donators.RemoveRange(db.Donators.Where(g => g.Name == "待打赏"));//批量删除
                }

                #endregion

            }
            #endregion


            #region 把对象附加到上下文中，然后删除

            using (MasDBContext db = new MasDBContext())
            {

                Donator entity = new Donator();
                entity.DonatorId = 1;
                //也是要跟踪当前的实体对象
                db.Donators.Attach(entity);
                //将状态设置为Deleted
                db.Donators.Remove(entity);
                db.SaveChanges();

            }

            #endregion


            #region 将DBEntityEntry状态设置为Deleted

            using (MasDBContext db = new MasDBContext())
            {

                Donator entity = new Donator();
                entity.DonatorId = 1;
                //也是要跟踪当前的实体对象
                db.Donators.Attach(entity);

                //将DBEntityEntry状态设置为Deleted
                db.Entry(entity).State = EntityState.Deleted;
                db.SaveChanges();

            }

            #endregion


            Console.Write("DB has Deleted!");//提示DB创建成功
            Console.Read();

        }




        /// <summary>
        /// 事务操作
        /// </summary>
        static void Transaction()
        {
            #region 显示事务

            //隐形事务
            using (MasDBContext db = new MasDBContext())
            {
                //db.Database.Connection.Open();//打开数据库连接

                using (DbContextTransaction tran = db.Database.BeginTransaction())
                {
                    try
                    {
                        Donator article = new Donator()
                        {
                            Name = "陈志康",
                            Amount = 50,
                            DonateDate = new DateTime(2016, 4, 7)
                        };

                        db.Donators.Add(article);
                        db.SaveChanges();

                        article = new Donator()
                        {
                            Name = "陈志康",
                            Amount = 50,
                            DonateDate = new DateTime(2016, 4, 7)
                        };

                        db.Donators.Add(article);
                        db.SaveChanges();

                        //提交事务
                        tran.Commit();

                    }
                    catch (Exception ex)
                    {
                        //回滚事务
                        tran.Rollback();
                        throw ex;
                    }
                }
            }

            #endregion


            #region 分布式事务 (显示事务)
            //分布式事务 (显示事务)

            using (TransactionScope tran = new TransactionScope())
            {

                #region 新增一

                using (MasDBContext db = new MasDBContext())
                {

                    try
                    {
                        Donator article = new Donator()
                        {
                            Name = "陈志康",
                            Amount = 50,
                            DonateDate = new DateTime(2016, 4, 7)
                        };

                        db.Donators.Add(article);
                        db.SaveChanges();

                        article = new Donator()
                        {
                            Name = "陈志康",
                            Amount = 50,
                            DonateDate = new DateTime(2016, 4, 7)
                        };

                        db.Donators.Add(article);
                        db.SaveChanges();



                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }

                #endregion


                //其他DBContext


                #region 新增二

                using (MasDBContext db = new MasDBContext())
                {

                    try
                    {
                        Donator article = new Donator()
                        {
                            Name = "陈志康",
                            Amount = 50,
                            DonateDate = new DateTime(2016, 4, 7)
                        };

                        db.Donators.Add(article);
                        db.SaveChanges();

                        article = new Donator()
                        {
                            Name = "陈志康",
                            Amount = 50,
                            DonateDate = new DateTime(2016, 4, 7)
                        };

                        db.Donators.Add(article);
                        db.SaveChanges();



                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                #endregion

                //提交事务
                //tran.Complete();
            }

            #endregion
        }





        /// <summary>
        /// 异步操作
        /// </summary>
        async static void InsertAsync()
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
                donators.ForEach(g => db.Entry(g).State = EntityState.Added);

                int result = await db.SaveChangesAsync();//支持异步操作
            }
        }









    }
}
