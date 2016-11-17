namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PlayerScore : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Players", "PlayerScore", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Players", "PlayerScore");
        }
    }
}
