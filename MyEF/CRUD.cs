using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEF
{
    public class CRUD
    {


        public static void Run()
        {
            YCSelect();
        }





        /// <summary>
        /// 查询记录——YCSelect
        /// </summary>
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
                    foreach (var sub in donator.PayWays)
                    {
                        Console.WriteLine("{0}\t\t{1}\t\t{2}", sub.Id, sub.Name, sub.donator.Amount);
                    }
                }
            }

            #endregion


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




        /// <summary>
        /// 更新记录——Update
        /// </summary>
        static void Update()
        {
            #region 先查询，后修改

            using (MasDBContext db = new MasDBContext())
            {

                #region 3.0 更新记录

                var toBeUpdatedDonator = db.Donators.FirstOrDefault(d => d.Name == "醉千秋");
                if (toBeUpdatedDonator != null)
                {
                    toBeUpdatedDonator.Name = "醉、千秋";
                    db.SaveChanges();
                }


                #endregion
            }

            #endregion





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

                db.Donators.Attach(entity);
                db.Donators.Remove(entity);
                db.SaveChanges();

            }

            #endregion


            #region 将DBEntityEntry状态设置为Deleted

            using (MasDBContext db = new MasDBContext())
            {

                Donator entity = new Donator();
                entity.DonatorId = 1;

                db.Donators.Attach(entity);

                //将DBEntityEntry状态设置为Deleted
                db.Entry(entity).State = EntityState.Deleted;
                db.SaveChanges();

            }

            #endregion

        }


    }
}
