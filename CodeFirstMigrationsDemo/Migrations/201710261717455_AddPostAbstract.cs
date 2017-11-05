namespace CodeFirstMigrationsDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPostAbstract : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Abstract", c => c.String());

            //���ɵ�Ǩ�Ƹ���ģʽ���ģ�������Ҳϣ��ʹ��ÿ�����ӵ�ǰ100���ַ�������Ԥ�������С�
            //���ǿ���ͨ���������֮���½���SQL������UPDATE�����ʵ��
            Sql("UPDATE dbo.Posts SET Abstract = LEFT(Content, 100) WHERE Abstract IS NULL");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "Abstract");
        }
    }
}
