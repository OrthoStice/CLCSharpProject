namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hackingscoresmodelforMVPlasttime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Scores", "SingleScore", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Scores", "SingleScore");
        }
    }
}
