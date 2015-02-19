namespace Lisa.Example.WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alerts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Catagory_Id = c.Int(),
                        Location_Id = c.Int(),
                        Reporter_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Catagories", t => t.Catagory_Id)
                .ForeignKey("dbo.Locations", t => t.Location_Id)
                .ForeignKey("dbo.Reporters", t => t.Reporter_Id)
                .Index(t => t.Catagory_Id)
                .Index(t => t.Location_Id)
                .Index(t => t.Reporter_Id);
            
            CreateTable(
                "dbo.Catagories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reporters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TelephoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Alerts", "Reporter_Id", "dbo.Reporters");
            DropForeignKey("dbo.Alerts", "Location_Id", "dbo.Locations");
            DropForeignKey("dbo.Alerts", "Catagory_Id", "dbo.Catagories");
            DropIndex("dbo.Alerts", new[] { "Reporter_Id" });
            DropIndex("dbo.Alerts", new[] { "Location_Id" });
            DropIndex("dbo.Alerts", new[] { "Catagory_Id" });
            DropTable("dbo.Reporters");
            DropTable("dbo.Locations");
            DropTable("dbo.Catagories");
            DropTable("dbo.Alerts");
        }
    }
}
