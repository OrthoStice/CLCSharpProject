namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hackingscoresmodelforMVP : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Scores", "GameId", "dbo.Games");
            DropForeignKey("dbo.Scores", "PlayerId", "dbo.Players");
            DropIndex("dbo.Scores", new[] { "GameId" });
            DropIndex("dbo.Scores", new[] { "PlayerId" });
            RenameColumn(table: "dbo.Scores", name: "GameId", newName: "game_Id");
            RenameColumn(table: "dbo.Scores", name: "PlayerId", newName: "player_Id");
            AlterColumn("dbo.Scores", "game_Id", c => c.Int());
            AlterColumn("dbo.Scores", "player_Id", c => c.Int());
            CreateIndex("dbo.Scores", "game_Id");
            CreateIndex("dbo.Scores", "player_Id");
            AddForeignKey("dbo.Scores", "game_Id", "dbo.Games", "Id");
            AddForeignKey("dbo.Scores", "player_Id", "dbo.Players", "Id");
            DropColumn("dbo.Scores", "TurnNum");
            DropColumn("dbo.Scores", "TurnTime");
            DropColumn("dbo.Scores", "TurnScore");
            DropColumn("dbo.Scores", "GameName");
            DropColumn("dbo.Scores", "PlayerName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Scores", "PlayerName", c => c.String());
            AddColumn("dbo.Scores", "GameName", c => c.String());
            AddColumn("dbo.Scores", "TurnScore", c => c.Int(nullable: false));
            AddColumn("dbo.Scores", "TurnTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Scores", "TurnNum", c => c.Int(nullable: false));
            DropForeignKey("dbo.Scores", "player_Id", "dbo.Players");
            DropForeignKey("dbo.Scores", "game_Id", "dbo.Games");
            DropIndex("dbo.Scores", new[] { "player_Id" });
            DropIndex("dbo.Scores", new[] { "game_Id" });
            AlterColumn("dbo.Scores", "player_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Scores", "game_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Scores", name: "player_Id", newName: "PlayerId");
            RenameColumn(table: "dbo.Scores", name: "game_Id", newName: "GameId");
            CreateIndex("dbo.Scores", "PlayerId");
            CreateIndex("dbo.Scores", "GameId");
            AddForeignKey("dbo.Scores", "PlayerId", "dbo.Players", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Scores", "GameId", "dbo.Games", "Id", cascadeDelete: true);
        }
    }
}
