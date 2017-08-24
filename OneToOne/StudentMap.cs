using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToOne
{
    public class StudentMap : EntityTypeConfiguration<Student>
    {

        public StudentMap()
        {
            HasRequired(s => s.Person).//前者(A)包含后者(B)一个不为null的实例
            WithOptional(p => p.Student);//后者(B)可以包含前者(A)一个实例或者null
            HasKey(s => s.PersonId);//指定了一个表的主键
            Property(s => s.CollegeName)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
