using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<MasContext>());

            using (MasContext db = new MasContext())
            {

                db.Demo.Add(new Demo()
                {
                    ID = 1,
                    AddTime = DateTime.Now,
                    M = 12.22M,
                    Name = "mas" + new Random().Next(),
                });
                db.SaveChanges();

            }



            Task t = new Task(() =>
            {
                using (MasContext db = new MasContext())
                {
                    var info = db.Demo.FirstOrDefault();
                    info.M = new Random().Next(1, 1000);

                    try
                    {
                        db.SaveChanges();
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {

                        #region 2.1 数据库优先方式
                        //原理是在出现异常的时候，重新加载数据库中的数据，覆盖Context本地数据
                        /*
                        ex.Entries.Single().Reload();
                        db.SaveChanges();
                         * 
                         */
                        #endregion


                        #region 2.2 客户端优先方式
                        //以Context保存的客户端数据为主，覆盖数据库中的数据
                        var entry = ex.Entries.Single();
                        entry.OriginalValues.SetValues(entry.GetDatabaseValues());
                        db.SaveChanges();
                        #endregion

                    }

                }
            });

            Task t2 = new Task(() =>
            {
                using (MasContext db = new MasContext())
                {
                    var info = db.Demo.FirstOrDefault();
                    info.M = new Random().Next(1, 1000);

                    try
                    {
                        db.SaveChanges();
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {

                        var entry = ex.Entries.Single();
                        entry.OriginalValues.SetValues(entry.GetDatabaseValues());
                        db.SaveChanges();
                    }

                }
            });

            t.Start();
            t2.Start();
            Task.WaitAll(t, t2);


            Console.WriteLine("结束");
            Console.ReadLine();

        }
    }
}
