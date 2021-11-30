namespace Fitnessapp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GetCaloriesBurnedByTrackerId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Workout", "CaloriesBurned", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Workout", "CaloriesBurned");
        }
    }
}
