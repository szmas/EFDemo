//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Test
{
    using System;
    using System.Collections.Generic;
    
    public partial class 组
    {
        public 组()
        {
            this.用户 = new HashSet<用户>();
        }
    
        public string 组1 { get; set; }
    
        public virtual ICollection<用户> 用户 { get; set; }
    }
}
