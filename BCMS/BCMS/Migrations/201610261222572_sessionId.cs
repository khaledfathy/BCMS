namespace BCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sessionId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Connections", "SessionId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Connections", "SessionId");
        }
    }
}
