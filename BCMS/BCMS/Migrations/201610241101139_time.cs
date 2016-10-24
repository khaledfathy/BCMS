namespace BCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class time : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Connections", "Time", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Connections", "Time");
        }
    }
}
