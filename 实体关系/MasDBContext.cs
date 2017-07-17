using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 实体关系
{
    class MasDBContext : DbContext
    {
        public MasDBContext()
            : base("name=FirstCodeFirstApp")
        {

        }

        public DbSet<Donator> Donators { get; set; }
        public DbSet<PayWay> PayWays { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


            //HasMany方法告诉EF在Donator和Payway类之间有一个一对多的关系。
            //WithRequired方法表明链接在PayWays属性上的Donator是必须的，
            //换言之，Payway对象不是独立的对象，必须要链接到一个Donator

            modelBuilder.Entity<Donator>().HasMany(d => d.PayWays)
                        .WithRequired()
                        .HasForeignKey(p => p.DonatorId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
