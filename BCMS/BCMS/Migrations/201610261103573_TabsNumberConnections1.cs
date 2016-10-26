namespace BCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TabsNumberConnections1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Connections", "TabsNumber", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Connections", "TabsNumber");
        }
    }
}
