namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deneme : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.PostLikes", newName: "EntryLikes");
            RenameTable(name: "dbo.Posts", newName: "Entries");
            RenameColumn(table: "dbo.Comments", name: "Post_Id", newName: "Entry_Id");
            RenameColumn(table: "dbo.EntryLikes", name: "Post_Id", newName: "Entry_Id");
            RenameIndex(table: "dbo.Comments", name: "IX_Post_Id", newName: "IX_Entry_Id");
            RenameIndex(table: "dbo.EntryLikes", name: "IX_Post_Id", newName: "IX_Entry_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.EntryLikes", name: "IX_Entry_Id", newName: "IX_Post_Id");
            RenameIndex(table: "dbo.Comments", name: "IX_Entry_Id", newName: "IX_Post_Id");
            RenameColumn(table: "dbo.EntryLikes", name: "Entry_Id", newName: "Post_Id");
            RenameColumn(table: "dbo.Comments", name: "Entry_Id", newName: "Post_Id");
            RenameTable(name: "dbo.Entries", newName: "Posts");
            RenameTable(name: "dbo.EntryLikes", newName: "PostLikes");
        }
    }
}
