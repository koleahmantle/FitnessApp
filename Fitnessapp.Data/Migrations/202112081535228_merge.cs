namespace Fitnessapp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class merge : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Recipe",
                c => new
                    {
                        RecipeId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        RecipeName = c.String(nullable: false),
                        Diet = c.String(nullable: false),
                        MealType = c.Double(nullable: false),
                        Calories = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RecipeId);
            
            CreateTable(
                "dbo.UserTrackerRecipe",
                c => new
                    {
                        UserTracker_UserTrackerId = c.Int(nullable: false),
                        Recipe_RecipeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserTracker_UserTrackerId, t.Recipe_RecipeId })
                .ForeignKey("dbo.UserTracker", t => t.UserTracker_UserTrackerId, cascadeDelete: true)
                .ForeignKey("dbo.Recipe", t => t.Recipe_RecipeId, cascadeDelete: true)
                .Index(t => t.UserTracker_UserTrackerId)
                .Index(t => t.Recipe_RecipeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserTrackerRecipe", "Recipe_RecipeId", "dbo.Recipe");
            DropForeignKey("dbo.UserTrackerRecipe", "UserTracker_UserTrackerId", "dbo.UserTracker");
            DropIndex("dbo.UserTrackerRecipe", new[] { "Recipe_RecipeId" });
            DropIndex("dbo.UserTrackerRecipe", new[] { "UserTracker_UserTrackerId" });
            DropTable("dbo.UserTrackerRecipe");
            DropTable("dbo.Recipe");
        }
    }
}
