namespace MyBlog.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Folders",
                c => new
                    {
                        FolderId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ImgUrl = c.String(),
                    })
                .PrimaryKey(t => t.FolderId);
            
            AddColumn("dbo.Images", "FolderId", c => c.String());
            DropColumn("dbo.Images", "FolderName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Images", "FolderName", c => c.String());
            DropColumn("dbo.Images", "FolderId");
            DropTable("dbo.Folders");
        }
    }
}
