namespace BCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveConnection : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Connections", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Connections", new[] { "UserId" });
            DropTable("dbo.Connections");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.ConnectionId);
            
            CreateIndex("dbo.Connections", "UserId");
            AddForeignKey("dbo.Connections", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
