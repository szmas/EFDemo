using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManyToMany
{
    class Program
    {



        /*
         
         
         * 班级和老师的关系。（一个班级有很多老师上课，一个老师可以去很多班级上课。）

         * 多对多其实就是：一对多 和 多对一 的一个组合。

         * 多对多的实现：多对多 必须要通过单独的一张表来表示。

            班级是一张表
            教师是一张表
            班级和教师的关系也是一张表
         
         
         */

        static void Main(string[] args)
        {

            using (MasContext db = new MasContext())
            {
                Menu menu = new Menu();
                menu.Name = "系统管理";
                menu.AddTime = DateTime.Now;
                menu.Remark = "系统管理";
                menu.Icon = "system.icon";
                menu.PID = 0;
                menu.Link = "/system/index.aspx";

                db.Menu.Add(menu);


                Role role = new Role();

                role.Name = "管理员";
                role.Remark = "管理员";
                role.AddTime = DateTime.Now;

                db.Role.Add(role);

                db.SaveChanges();
            }
        }
    }
}
