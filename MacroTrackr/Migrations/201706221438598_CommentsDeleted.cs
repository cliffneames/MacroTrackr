namespace MacroTrackr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommentsDeleted : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FoodItems", "UserID", c => c.String(maxLength: 128));
            CreateIndex("dbo.FoodItems", "UserID");
            AddForeignKey("dbo.FoodItems", "UserID", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FoodItems", "UserID", "dbo.AspNetUsers");
            DropIndex("dbo.FoodItems", new[] { "UserID" });
            DropColumn("dbo.FoodItems", "UserID");
        }
    }
}
