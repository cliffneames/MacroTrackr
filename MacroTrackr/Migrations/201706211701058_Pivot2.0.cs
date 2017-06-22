namespace MacroTrackr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Pivot20 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FoodItems",
                c => new
                    {
                        FoodItemID = c.Int(nullable: false, identity: true),
                        UserID = c.String(maxLength: 128),
                        TimeOfMeal = c.Int(nullable: false),
                        WhenEaten = c.DateTime(nullable: false),
                        Carbs = c.Single(nullable: false),
                        Protein = c.Single(nullable: false),
                        Fat = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.FoodItemID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FoodItems", "UserID", "dbo.AspNetUsers");
            DropIndex("dbo.FoodItems", new[] { "UserID" });
            DropTable("dbo.FoodItems");
        }
    }
}
