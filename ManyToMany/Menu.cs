using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManyToMany
{
    public class Menu
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public DateTime AddTime { get; set; }
        public string Icon { get; set; }
        public string Link { get; set; }

        public Nullable<int> PID { get; set; }

        public string Remark { get; set; }

        /// <summary>
        /// 一个菜单对应多个角色（多对多的关系）
        /// </summary>
        public virtual ICollection<Role> Roles { get; set; }
    }
}
