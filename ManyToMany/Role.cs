using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManyToMany
{
    public class Role
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime AddTime { get; set; }

        public string Remark { get; set; }


        /// <summary>
        /// 一个角色对应多个菜单（多对多的关系）
        /// </summary>
        public virtual ICollection<Menu> Menus { get; set; }
    }
}
