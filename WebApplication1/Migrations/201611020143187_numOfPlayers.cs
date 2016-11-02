namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class numOfPlayers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "numOfPlayers", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Games", "numOfPlayers");
        }
    }
}
