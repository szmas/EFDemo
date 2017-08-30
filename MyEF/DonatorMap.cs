using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEF
{
    class DonatorMap : EntityTypeConfiguration<Donator>
    {
        public DonatorMap()
        {
            ToTable("Donator");//配置此实体类型映射到的表名
            Property(m => m.Name)
                .IsRequired()//将Name设置为必须的
                .HasColumnName("DonatorName");//为了区别之前的结果，将Name映射到数据表的DonatorName
        }
    }
}
