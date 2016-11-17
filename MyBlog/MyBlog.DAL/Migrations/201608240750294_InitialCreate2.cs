namespace MyBlog.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Folders", "Description", c => c.String());
            AlterColumn("dbo.Images", "FolderId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Images", "FolderId", c => c.String());
            DropColumn("dbo.Folders", "Description");
        }
    }
}
