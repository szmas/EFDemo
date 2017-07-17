using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace MyEF
{

    /// <summary>
    /// 初始化器（Initializer）
    /// </summary>
    class Initializer : DropCreateDatabaseIfModelChanges<MasDBContext>
    {
        //默认使用第一个初始化器
        /*
         
         
         
         CreateDatabaseIfNotExists<TContext>  --指如果数据库不存在则创建，
         DropCreateDatabaseIfModelChanges<TContext>--指如果模型改变了（包括模型类的更改以及上下文中集合属性的添加和移除）就销毁之前的数据库再创建数据库
         DropCreateDatabaseAlways<TContext>--总是销毁再重新创建数据库，如果没有指定的话默认使用第一个初始化器。
         
         
         
         
         
         
         
         
         
         */



        /// <summary>
        /// 初始化器允许我们在目标数据库创建之后运行其他代码
        /// </summary>
        /// <param name="context"></param>
        protected override void Seed(MasDBContext context)
        {
            context.PayWays.AddRange(new List<PayWay>
                                    {
                                        new PayWay{Name = "支付宝"},
                                        new PayWay{Name = "微信"},
                                        new PayWay{Name = "QQ红包"}
                                    });
        }

    }
}
