using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Test
{
    public class Demo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//这个是自增列
        public int ID { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//这个是默认值约束
        public Guid GID { get; set; }

        [Required]
        [MaxLength(50)]
        [Index("Demo_Index_Name", IsUnique = true)]
        public string Name { get; set; }

        public decimal M { get; set; }
        public DateTime AddTime { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
