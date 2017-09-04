using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEF
{
    class MasDBContext : DbContext
    {
        public MasDBContext()
            : base("name=FirstCodeFirstApp")
        {

        }

        public MasDBContext(string connection) :
            base(connection)
        {
           
        }

        public DbSet<Donator> Donators { get; set; }
        public DbSet<PayWay> PayWays { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            //你可以看到上面的语法和写jQuery的链式编程一样，这种方法的链式写法就叫Fluent API。

            //使用fluent API的一个重要决定因素是我们是否使用了外部的POCO类，即实体模型类是否来自一个类库。
            //我们无法修改类库中类的定义，所以不能通过数据注解来提供映射细节。这种情况，我们必须使用fluent API。


            modelBuilder.Entity<Donator>().ToTable("Donators").HasKey(m => m.DonatorId);//映射到表Donators,DonatorId当作主键对待

            modelBuilder.Entity<Donator>().Property(m => m.DonatorId).HasColumnName("Id");//映射到数据表中的主键名为Id而不是DonatorId

            modelBuilder.Entity<Donator>().ToTable("Donators").Map(  //将关系配置为使用在对象模型中的外键属性。如果未在对象模型中公开外键属性

            modelBuilder.Entity<Donator>().Property(m => m.Name)
                .IsRequired()//设置Name是必须的，即不为null,默认是可为null的
                .IsUnicode()//设置Name列为Unicode字符，实际上默认就是unicode,所以该方法可不写
                .HasMaxLength(10);//最大长度为10


            //为每个实体类单独创建一个配置类
            modelBuilder.Configurations.Add(new DonatorMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
