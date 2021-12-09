namespace Fitnessapp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Intital : DbMigration
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
                "dbo.UserTracker",
                c => new
                    {
                        UserTrackerId = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        UserName = c.String(),
                        TagLine = c.String(),
                    })
                .PrimaryKey(t => t.UserTrackerId);
            
            CreateTable(
                "dbo.Workout",
                c => new
                    {
                        WorkoutId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Category = c.String(nullable: false),
                        Duration = c.Double(nullable: false),
                        Intensity = c.String(nullable: false),
                        CaloriesBurned = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WorkoutId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
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
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.UserTrackerRecipe", "Recipe_RecipeId", "dbo.Recipe");
            DropForeignKey("dbo.UserTrackerRecipe", "UserTracker_UserTrackerId", "dbo.UserTracker");
            DropForeignKey("dbo.WorkoutUserTracker", "UserTracker_UserTrackerId", "dbo.UserTracker");
            DropForeignKey("dbo.WorkoutUserTracker", "Workout_WorkoutId", "dbo.Workout");
            DropIndex("dbo.UserTrackerRecipe", new[] { "Recipe_RecipeId" });
            DropIndex("dbo.UserTrackerRecipe", new[] { "UserTracker_UserTrackerId" });
            DropIndex("dbo.WorkoutUserTracker", new[] { "UserTracker_UserTrackerId" });
            DropIndex("dbo.WorkoutUserTracker", new[] { "Workout_WorkoutId" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropTable("dbo.UserTrackerRecipe");
            DropTable("dbo.WorkoutUserTracker");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Workout");
            DropTable("dbo.UserTracker");
            DropTable("dbo.Recipe");
        }
    }
}
