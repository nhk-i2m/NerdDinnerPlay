namespace NerdDinner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Name1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IntraAgents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        IntraUserName = c.String(),
                        IntraPassword = c.String(),
                        AgentRunning = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.IntraAgents");
        }
    }
}
