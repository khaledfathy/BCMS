namespace BCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditPetrochemical : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Petrochemicals", "Rabigh8_Prod", c => c.Double());
            AddColumn("dbo.Petrochemicals", "Rabigh8_Per", c => c.Double());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Petrochemicals", "Rabigh8_Per");
            DropColumn("dbo.Petrochemicals", "Rabigh8_Prod");
        }
    }
}
