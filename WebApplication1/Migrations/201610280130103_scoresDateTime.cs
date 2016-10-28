namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class scoresDateTime : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Scores", "GameId");
            CreateIndex("dbo.Scores", "PlayerId");
            AddForeignKey("dbo.Scores", "GameId", "dbo.Games", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Scores", "PlayerId", "dbo.Players", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Scores", "PlayerId", "dbo.Players");
            DropForeignKey("dbo.Scores", "GameId", "dbo.Games");
            DropIndex("dbo.Scores", new[] { "PlayerId" });
            DropIndex("dbo.Scores", new[] { "GameId" });
            
        }
    }
}
