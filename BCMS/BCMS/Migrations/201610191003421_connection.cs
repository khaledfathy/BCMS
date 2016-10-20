namespace BCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class connection : DbMigration
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
                    })
                .PrimaryKey(t => t.ConnectionId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            
        }
        
        public override void Down()
        {
            
        }
    }
}
