using System;
using System.Collections.Generic;
using System.Data.Entity;
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


            /*
            db.Demo.Add(new Demo()
            {
                ID = 1,
                AddTime = DateTime.Now,
                M = 12.22M,
                Name = "mass",
            });
            db.SaveChanges();
            */


            Task t = new Task(() =>
            {
                using (MasContext db = new MasContext())
                {
                    var info = db.Demo.FirstOrDefault();
                    info.M = new Random().Next(1, 1000);

                    db.SaveChanges();
                }
            });

            Task t2 = new Task(() =>
            {
                using (MasContext db = new MasContext())
                {
                    var info = db.Demo.FirstOrDefault();
                    info.M = new Random().Next(1, 1000);

                    db.SaveChanges();
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
