using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToOne
{
    public class Person
    {
        [Key]
        //[ForeignKey("Student")]//外键
        public int PersonId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public virtual Student Student { get; set; }

    }
}
