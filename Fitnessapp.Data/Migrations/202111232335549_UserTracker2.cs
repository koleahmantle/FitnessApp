namespace Fitnessapp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserTracker2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WorkoutUserTracker", "Workout_WorkoutId", "dbo.Workout");
            DropForeignKey("dbo.WorkoutUserTracker", "UserTracker_UserTrackerId", "dbo.UserTracker");
            DropIndex("dbo.WorkoutUserTracker", new[] { "Workout_WorkoutId" });
            DropIndex("dbo.WorkoutUserTracker", new[] { "UserTracker_UserTrackerId" });
            DropTable("dbo.WorkoutUserTracker");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.WorkoutUserTracker",
                c => new
                    {
                        Workout_WorkoutId = c.Int(nullable: false),
                        UserTracker_UserTrackerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Workout_WorkoutId, t.UserTracker_UserTrackerId });
            
            CreateIndex("dbo.WorkoutUserTracker", "UserTracker_UserTrackerId");
            CreateIndex("dbo.WorkoutUserTracker", "Workout_WorkoutId");
            AddForeignKey("dbo.WorkoutUserTracker", "UserTracker_UserTrackerId", "dbo.UserTracker", "UserTrackerId", cascadeDelete: true);
            AddForeignKey("dbo.WorkoutUserTracker", "Workout_WorkoutId", "dbo.Workout", "WorkoutId", cascadeDelete: true);
        }
    }
}
