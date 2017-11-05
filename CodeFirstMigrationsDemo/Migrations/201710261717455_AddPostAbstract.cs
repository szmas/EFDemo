namespace CodeFirstMigrationsDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPostAbstract : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Abstract", c => c.String());

            //生成的迁移负责模式更改，但我们也希望使用每个帖子的前100个字符的内容预填充抽象列。
            //我们可以通过在添加列之后下降到SQL并运行UPDATE语句来实现
            Sql("UPDATE dbo.Posts SET Abstract = LEFT(Content, 100) WHERE Abstract IS NULL");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "Abstract");
        }
    }
}
