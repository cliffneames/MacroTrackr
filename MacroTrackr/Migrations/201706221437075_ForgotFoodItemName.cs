namespace MacroTrackr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForgotFoodItemName : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FoodItems", "UserID", "dbo.AspNetUsers");
            DropIndex("dbo.FoodItems", new[] { "UserID" });
            AddColumn("dbo.FoodItems", "Name", c => c.String());
            DropColumn("dbo.FoodItems", "UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FoodItems", "UserID", c => c.String(maxLength: 128));
            DropColumn("dbo.FoodItems", "Name");
            CreateIndex("dbo.FoodItems", "UserID");
            AddForeignKey("dbo.FoodItems", "UserID", "dbo.AspNetUsers", "Id");
        }
    }
}
