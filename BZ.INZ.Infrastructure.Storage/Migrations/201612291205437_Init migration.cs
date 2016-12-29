namespace BZ.INZ.Infrastructure.Storage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Pesel = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.JobOffers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        EmployerId = c.Guid(nullable: false),
                        Name = c.String(),
                        Content = c.String(),
                        DateRequested = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.JobOffers");
            DropTable("dbo.Employers");
        }
    }
}
