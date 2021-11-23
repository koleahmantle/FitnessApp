namespace Fitnessapp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserTracker1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserTracker", "UserName", c => c.String());
            AddColumn("dbo.UserTracker", "TagLine", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserTracker", "TagLine");
            DropColumn("dbo.UserTracker", "UserName");
        }
    }
}
