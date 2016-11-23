namespace BCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddConnection : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Connections",
                c => new
                    {
                        ConnectionId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(maxLength: 128),
                        Email = c.String(),
                        Time = c.DateTime(nullable: false),
                        TabsNumber = c.Byte(nullable: false),
                        SessionId = c.String(),
                    })
                .PrimaryKey(t => t.ConnectionId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Connections", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Connections", new[] { "UserId" });
            DropTable("dbo.Connections");
        }
    }
}
