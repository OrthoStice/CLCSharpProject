namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hackingscoresmodelforMVPlasttimereallytruly : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Scores", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Scores", "UserId");
        }
    }
}
