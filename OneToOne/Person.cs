using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToOne
{

    /// <summary>
    /// Person的外键是Student的主键，反过来Student的外键是Person的主键，这样就构成了OneToOne
    /// </summary>
    [Table("Person")]
    public class Person
    {
        [Key]

        public int PersonId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }



        /// <summary>
        /// 设置外键
        /// </summary>
        [ForeignKey("Student")]
        public int SID { get; set; }
        /// <summary>
        /// 延迟加载
        /// </summary>
        public virtual Student Student { get; set; }

    }
}
