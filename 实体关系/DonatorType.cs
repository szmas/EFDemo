using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 实体关系
{
    class DonatorType
    {
        public int Id { set; get; }
        public string Name { set; get; }

        public virtual ICollection<Donator> Donators { get; set; }
    }
}
