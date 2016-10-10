namespace BCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class petrochemical : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Petrochemicals",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        Usage = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Sabic36_Prod = c.Double(),
                        Sabic36_Per = c.Double(),
                        Petrochem_Prod = c.Double(),
                        Petrochem_Per = c.Double(),
                        Safco2_Prod = c.Double(),
                        Safco2_Per = c.Double(),
                        Kayan14_Prod = c.Double(),
                        Kayan14_Per = c.Double(),
                        Yansab15_Prod = c.Double(),
                        Yansab15_Per = c.Double(),
                        Sipchem8_Prod = c.Double(),
                        Sipchem8_Per = c.Double(),
                        Siig10_Prod = c.Double(),
                        Siig10_Per = c.Double(),
                        Tasnee8_Prod = c.Double(),
                        Tasnee8_Per = c.Double(),
                        Sahara8_Prod = c.Double(),
                        Sahara8_Per = c.Double(),
                        Chemanol10_Prod = c.Double(),
                        Chemanol10_Per = c.Double(),
                        Alujain1_Prod = c.Double(),
                        Alujain1_Per = c.Double(),
                        Advanced_Prod = c.Double(),
                        Advanced_Per = c.Double(),
                        Nama_Prod = c.Double(),
                        Nama_Per = c.Double(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Petrochemicals");
        }
    }
}
