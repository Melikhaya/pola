namespace WebApplication6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmailModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        From = c.String(),
                        Subject = c.String(),
                        Body = c.String(),
                        Urgancy = c.String(),
                        IpAddress = c.String(),
                        Location = c.String(),
                        date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EmailModels");
        }
    }
}
