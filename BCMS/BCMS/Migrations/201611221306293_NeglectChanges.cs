namespace BCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NeglectChanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Connections", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Connections", new[] { "UserId" });
            DropPrimaryKey("dbo.Connections");
            AlterColumn("dbo.Connections", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Connections", "ConnectionId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Connections", "ConnectionId");
            CreateIndex("dbo.Connections", "UserId");
            AddForeignKey("dbo.Connections", "UserId", "dbo.AspNetUsers", "Id");
            DropForeignKey("dbo.Connections", "User_Id", "dbo.AspNetUsers");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Connections", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Connections", new[] { "UserId" });
            DropPrimaryKey("dbo.Connections");
            AlterColumn("dbo.Connections", "ConnectionId", c => c.String());
            AlterColumn("dbo.Connections", "UserId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Connections", "UserId");
            CreateIndex("dbo.Connections", "UserId");
            AddForeignKey("dbo.Connections", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            DropForeignKey("dbo.Connections", "User_Id", "dbo.AspNetUsers");
        }
    }
}
