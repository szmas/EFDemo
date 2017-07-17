using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 实体关系
{
    class DonatorTypeMap : EntityTypeConfiguration<DonatorType>
    {
        public DonatorTypeMap()
        {
            HasMany(dt => dt.Donators)
            .WithOptional(d => d.DonatorType)
            .HasForeignKey(d => d.DonatorTypeId)
            .WillCascadeOnDelete(false);

            /*
             
             * 
             * WithOptional方法表示外键约束可以为空，使用WillCascadeOnDelete方法可以指定约束的删除规则。
             * 对于外键关系约束，大多数数据库引擎都支持删除规则的多操作，这些规则指定了当一个父亲删除之后会发生什么。
             * 将外键列设置为null之后，如果孩子不存在或者删除了所有相关的依赖就会报错。
             * EF允许开发者要么删除所有的孩子行，要么啥也别做。一些数据库管理员反对级联删除，
             * 因为一些数据库引擎没有提供级联删除时的充足的日志信息。
             * 
             * 
             
             
             */

        }
    }
}
