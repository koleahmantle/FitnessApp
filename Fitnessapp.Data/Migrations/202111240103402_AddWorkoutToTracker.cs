namespace Fitnessapp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWorkoutToTracker : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WorkoutUserTracker",
                c => new
                    {
                        Workout_WorkoutId = c.Int(nullable: false),
                        UserTracker_UserTrackerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Workout_WorkoutId, t.UserTracker_UserTrackerId })
                .ForeignKey("dbo.Workout", t => t.Workout_WorkoutId, cascadeDelete: true)
                .ForeignKey("dbo.UserTracker", t => t.UserTracker_UserTrackerId, cascadeDelete: true)
                .Index(t => t.Workout_WorkoutId)
                .Index(t => t.UserTracker_UserTrackerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkoutUserTracker", "UserTracker_UserTrackerId", "dbo.UserTracker");
            DropForeignKey("dbo.WorkoutUserTracker", "Workout_WorkoutId", "dbo.Workout");
            DropIndex("dbo.WorkoutUserTracker", new[] { "UserTracker_UserTrackerId" });
            DropIndex("dbo.WorkoutUserTracker", new[] { "Workout_WorkoutId" });
            DropTable("dbo.WorkoutUserTracker");
        }
    }
}
