namespace MacroTrackr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NutrinionixNameAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MacroNutrients", "NutritionixName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MacroNutrients", "NutritionixName");
        }
    }
}
