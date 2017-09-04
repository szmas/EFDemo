using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToOne
{
    public class Student
    {

        [Key]//主键
        //[ForeignKey("Person")]
        public int PersonId { get; set; }
        
        public string CollegeName { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public virtual Person Person { get; set; }
    }
}
