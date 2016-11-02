namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class numOfPlayers2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Games", "GameName", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Games", "GameName", c => c.String());
        }
    }
}
