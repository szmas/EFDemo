using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEF.延迟加载
{
    public class Demo
    {

        /*
         
            首先EntityFramework6的延迟加载默认是被支持的，
            可以通过设置context.Configuration.LazyLoadingEnabled = false来禁止。
            当启用延迟加载的时候，EntityFramework访问实体的相关对象时，
            也就是一对一、一对多的属性时，EntityFramework会从你定义的实体派生出一个动态对象，
            然后覆盖你的子实体集合访问属性来实现。所以我们在定义POCO类的时候，会在关系属性前加上virtual 来修饰。
            如果不加修饰，就不会启动延迟加载。
            延迟加载，就是在查找某个实体时，会把相关联的实体对象或者集合全部加载出来。
         
          
          
         从上面的结果可以看出，当我们需要获取Role对象的时候，EntityFramework会把与之关联的对象以动态代理对象(DynamicProxy)
　　     的方式加载出来，数据库也向与之关联的表执行了多个关联查询才得到结果。
         */


        public static void Run()
        {
            using (var db = new MasDBContext())
            {
                //不会把PayWays的表数据加载过来
                var info = db.Donators.FirstOrDefault();

                //延迟加载 ，当获取的时候就会加载过来
                var paywayInfo = info.PayWays;
            }

            using (var db = new MasDBContext())
            {
                //禁用延迟加载
                db.Configuration.ProxyCreationEnabled = false;
                db.Configuration.LazyLoadingEnabled = false;

                //不会把PayWays的表数据加载过来
                var info = db.Donators.FirstOrDefault();

                //paywayInfo的值为空，不会加载数据
                var paywayInfo = info.PayWays;


                //从上面的结果可以看出，执行的结果只有Role对象，与之关联的对象S_Menus为null,S_Users也没有结果，
                //说明在禁用延迟加载的情况下，EntityFramework只对当前执行的上下文对象进行查询。
            }
        }
    }
}
