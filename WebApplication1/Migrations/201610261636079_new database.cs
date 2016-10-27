namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newdatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GameName = c.String(),
                        GameStartDate = c.DateTime(nullable: false),
                        UserId_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId_Id)
                .Index(t => t.UserId_Id);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlayerFirstName = c.String(),
                        PlayerGameName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Scores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GameID = c.Int(nullable: false),
                        TurnNum = c.Int(nullable: false),
                        TurnTime = c.DateTime(nullable: false),
                        PlayerID = c.Int(nullable: false),
                        TurnScore = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Games", "UserId_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Games", new[] { "UserId_Id" });
            DropTable("dbo.Scores");
            DropTable("dbo.Players");
            DropTable("dbo.Games");
        }
    }
}
