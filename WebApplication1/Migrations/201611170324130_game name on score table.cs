namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gamenameonscoretable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Scores", "GameName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Scores", "GameName");
        }
    }
}
