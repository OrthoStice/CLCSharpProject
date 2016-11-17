namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hackingscoresmodelforMVPtry2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Scores", "game_Id", "dbo.Games");
            DropForeignKey("dbo.Scores", "player_Id", "dbo.Players");
            DropIndex("dbo.Scores", new[] { "game_Id" });
            DropIndex("dbo.Scores", new[] { "player_Id" });
            AddColumn("dbo.Scores", "GameName", c => c.String());
            AddColumn("dbo.Scores", "PlayerName", c => c.String());
            AddColumn("dbo.Scores", "TempScoreID", c => c.String());
            DropColumn("dbo.Scores", "game_Id");
            DropColumn("dbo.Scores", "player_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Scores", "player_Id", c => c.Int());
            AddColumn("dbo.Scores", "game_Id", c => c.Int());
            DropColumn("dbo.Scores", "TempScoreID");
            DropColumn("dbo.Scores", "PlayerName");
            DropColumn("dbo.Scores", "GameName");
            CreateIndex("dbo.Scores", "player_Id");
            CreateIndex("dbo.Scores", "game_Id");
            AddForeignKey("dbo.Scores", "player_Id", "dbo.Players", "Id");
            AddForeignKey("dbo.Scores", "game_Id", "dbo.Games", "Id");
        }
    }
}
