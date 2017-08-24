using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToOne
{
    class MasContext : DbContext
    {

        public MasContext()
            : base("name=MasContext")
        {

        }

        public DbSet<Student> Student { get; set; }
        public DbSet<Person> Person { get; set; }

    }
}
