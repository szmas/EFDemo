using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToOne
{
    public class PersonMap : EntityTypeConfiguration<Person>
    {

        public PersonMap()
        {

            //ToTable("Product");
            //ToTable("Product", "newdbo");//指定schema，不使用默认的dbo
            //HasKey(p => p.PersonId);//普通主键
            //HasKey(p => new { p.PersonId, p.Name });//关联主键
            //Property(p => p.PersonId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);//不让主键作为Identity自动生成
            //Property(p => p.Name).IsRequired().HasMaxLength(20).HasColumnName("ProductName").IsUnicode(false);//非空，最大长度20，自定义列名，列类型为varchar而非nvarchar
            //Ignore(p => p.Description);


            this.HasKey(p => p.PersonId);  //主键
            this.Property(p => p.Name).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            //this.Property(p => p.RowVersion).IsRowVersion();  //时间戳
            this.Property(p => p.Name).IsConcurrencyToken();  //ConcurrencyCheck并发
        }
    }
}
