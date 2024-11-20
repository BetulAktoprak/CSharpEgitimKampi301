namespace CSharpEgitimKampi301.EFProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Guides",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        City = c.String(),
                        Country = c.String(),
                        Capacity = c.Byte(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DayNight = c.String(),
                        GuideId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Guides", t => t.GuideId, cascadeDelete: true)
                .Index(t => t.GuideId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Locations", "GuideId", "dbo.Guides");
            DropIndex("dbo.Locations", new[] { "GuideId" });
            DropTable("dbo.Locations");
            DropTable("dbo.Guides");
            DropTable("dbo.Customers");
            DropTable("dbo.Admins");
        }
    }
}
