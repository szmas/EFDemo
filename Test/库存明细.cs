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
    
    public partial class 库存明细
    {
        public string 物料编号 { get; set; }
        public decimal 数量 { get; set; }
        public string 仓位 { get; set; }
        public string 备注 { get; set; }
    
        public virtual 物料资料 物料资料 { get; set; }
    }
}
