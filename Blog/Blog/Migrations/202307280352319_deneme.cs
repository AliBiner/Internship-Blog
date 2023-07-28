namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deneme : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "About", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "About");
        }
    }
}
