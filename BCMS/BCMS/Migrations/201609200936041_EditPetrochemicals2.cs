namespace BCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditPetrochemicals2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Petrochemicals", "Price", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Petrochemicals", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
