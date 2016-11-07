namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newplayerguid : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Scores", "PlayerId", "dbo.Players");
            DropIndex("dbo.Scores", new[] { "PlayerId" });
            DropPrimaryKey("dbo.Players");
            AlterColumn("dbo.Players", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Scores", "PlayerId", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Players", "Id");
            CreateIndex("dbo.Scores", "PlayerId");
            AddForeignKey("dbo.Scores", "PlayerId", "dbo.Players", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Scores", "PlayerId", "dbo.Players");
            DropIndex("dbo.Scores", new[] { "PlayerId" });
            DropPrimaryKey("dbo.Players");
            AlterColumn("dbo.Scores", "PlayerId", c => c.Int(nullable: false));
            AlterColumn("dbo.Players", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Players", "Id");
            CreateIndex("dbo.Scores", "PlayerId");
            AddForeignKey("dbo.Scores", "PlayerId", "dbo.Players", "Id", cascadeDelete: true);
        }
    }
}
