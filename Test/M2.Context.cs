﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class qds236354159_dbEntities7 : DbContext
    {
        public qds236354159_dbEntities7()
            : base("name=qds236354159_dbEntities7")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<PreSale> PreSale { get; set; }
        public virtual DbSet<PreSaleDetail> PreSaleDetail { get; set; }
        public virtual DbSet<备货单> 备货单 { get; set; }
        public virtual DbSet<备货单明细> 备货单明细 { get; set; }
        public virtual DbSet<补货单> 补货单 { get; set; }
        public virtual DbSet<补货单明细> 补货单明细 { get; set; }
        public virtual DbSet<采购单> 采购单 { get; set; }
        public virtual DbSet<采购单明细> 采购单明细 { get; set; }
        public virtual DbSet<采购入库> 采购入库 { get; set; }
    }
}
