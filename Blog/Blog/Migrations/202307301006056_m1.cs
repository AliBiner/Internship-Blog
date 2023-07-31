namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Slug = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(),
                        DeleteDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Entries",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        MetaTitle = c.String(),
                        Slug = c.String(),
                        Description = c.String(),
                        Published = c.Boolean(nullable: false),
                        Image1 = c.Binary(),
                        Image2 = c.Binary(),
                        UserId = c.Guid(nullable: false),
                        CategoryId = c.Guid(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(),
                        DeleteDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        Summary = c.String(),
                        Published = c.Boolean(),
                        EntryId = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(),
                        DeleteDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entries", t => t.EntryId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .Index(t => t.EntryId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        MiddleName = c.String(),
                        Surname = c.String(),
                        Email = c.String(nullable: false, maxLength: 50),
                        Phone = c.String(nullable: false, maxLength: 15),
                        PasswordHash = c.String(),
                        Role = c.String(),
                        ProfileDescription = c.String(),
                        Image = c.Binary(),
                        LostLogin = c.DateTime(),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(),
                        DeleteDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Email, unique: true)
                .Index(t => t.Phone, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "UserId", "dbo.Users");
            DropForeignKey("dbo.Entries", "UserId", "dbo.Users");
            DropForeignKey("dbo.Comments", "EntryId", "dbo.Entries");
            DropForeignKey("dbo.Entries", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Users", new[] { "Phone" });
            DropIndex("dbo.Users", new[] { "Email" });
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropIndex("dbo.Comments", new[] { "EntryId" });
            DropIndex("dbo.Entries", new[] { "CategoryId" });
            DropIndex("dbo.Entries", new[] { "UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.Comments");
            DropTable("dbo.Entries");
            DropTable("dbo.Categories");
        }
    }
}
