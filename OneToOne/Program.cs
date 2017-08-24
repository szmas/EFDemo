using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToOne
{

    class Program
    {
        static void Main(string[] args)
        {

            /*
             
             * 一对一的实现：既可以把表A的主键充当表B的外键，也可以把表B的主键充当表A的外键
             
             
             */

            using (MasContext db = new MasContext())
            {

                #region 7 一对一关系

                /*
                 * 下图中的两张表的主键是一一对应的。
                 * 
                 * Student表可以没有对应的Person表数据，但是Person表每一条数据都必须对应一条Student表数据
                 * 
                 * 因为该关系是可选的，所以它也称为一或零对一（One-or-Zero-to-One）。
                 * 关系的两端都是必须要存在的关系称为一对一。
                 * 比如，每个人必须要有一个单独的login，这是强制性的。
                 * 你也可以使用WithRequiredDepentent或者WithRequiredPrincipal方法来代替WithOptional方法。
                 * 
                 * */


                //有学校可以没人
                var student = new Student
                {
                    CollegeName = "XX大学",
                    EnrollmentDate = DateTime.Parse("2011-11-11"),
                    Person = new Person()
                    {
                        Name = "allen",
                        IsActive = true
                    }
                };

                db.Student.Add(student);
                db.SaveChanges();


                //有人就必须有学校
                var person = new Person
                {
                    Name = "Mas",
                    Student = new Student()
                    {
                        CollegeName = "XX大学",
                        EnrollmentDate = DateTime.Parse("2011-11-11"),
                    }
                };

                db.Person.Add(person);
                db.SaveChanges();

                #endregion

            }
        }
    }
}
