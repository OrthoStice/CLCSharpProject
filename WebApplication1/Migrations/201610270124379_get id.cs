namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class getid : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Games", "UserId_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Games", new[] { "UserId_Id" });
            AddColumn("dbo.Games", "UserId", c => c.String());
            DropColumn("dbo.Games", "UserId_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Games", "UserId_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.Games", "UserId");
            CreateIndex("dbo.Games", "UserId_Id");
            AddForeignKey("dbo.Games", "UserId_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
