namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newviewmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Players", "PlayerGameID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Players", "PlayerGameID");
        }
    }
}
