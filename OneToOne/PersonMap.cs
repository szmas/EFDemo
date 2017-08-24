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
            this.HasKey(p => p.PersonId);  //主键
            this.Property(p => p.Name).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            //this.Property(p => p.RowVersion).IsRowVersion();  //时间戳
            this.Property(p => p.Name).IsConcurrencyToken();  //ConcurrencyCheck并发
        }
    }
}
