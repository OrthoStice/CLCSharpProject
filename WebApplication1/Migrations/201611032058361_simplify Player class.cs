namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class simplifyPlayerclass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Players", "PlayerName", c => c.String());
            DropColumn("dbo.Players", "PlayerFirstName");
            DropColumn("dbo.Players", "PlayerGameName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Players", "PlayerGameName", c => c.String());
            AddColumn("dbo.Players", "PlayerFirstName", c => c.String());
            DropColumn("dbo.Players", "PlayerName");
        }
    }
}
