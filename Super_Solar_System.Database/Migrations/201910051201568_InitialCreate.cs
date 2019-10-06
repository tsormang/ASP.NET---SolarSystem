namespace Super_Solar_System.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Habitants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Species = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Planets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 12),
                        Distance = c.Long(nullable: false),
                        Radius = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Moons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 12),
                        Distance = c.Long(nullable: false),
                        Radius = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PlanetHabitants",
                c => new
                    {
                        Planet_Id = c.Int(nullable: false),
                        Habitant_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Planet_Id, t.Habitant_Id })
                .ForeignKey("dbo.Planets", t => t.Planet_Id, cascadeDelete: true)
                .ForeignKey("dbo.Habitants", t => t.Habitant_Id, cascadeDelete: true)
                .Index(t => t.Planet_Id)
                .Index(t => t.Habitant_Id);
            
            CreateTable(
                "dbo.MoonPlanets",
                c => new
                    {
                        Moon_Id = c.Int(nullable: false),
                        Planet_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Moon_Id, t.Planet_Id })
                .ForeignKey("dbo.Moons", t => t.Moon_Id, cascadeDelete: true)
                .ForeignKey("dbo.Planets", t => t.Planet_Id, cascadeDelete: true)
                .Index(t => t.Moon_Id)
                .Index(t => t.Planet_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MoonPlanets", "Planet_Id", "dbo.Planets");
            DropForeignKey("dbo.MoonPlanets", "Moon_Id", "dbo.Moons");
            DropForeignKey("dbo.PlanetHabitants", "Habitant_Id", "dbo.Habitants");
            DropForeignKey("dbo.PlanetHabitants", "Planet_Id", "dbo.Planets");
            DropIndex("dbo.MoonPlanets", new[] { "Planet_Id" });
            DropIndex("dbo.MoonPlanets", new[] { "Moon_Id" });
            DropIndex("dbo.PlanetHabitants", new[] { "Habitant_Id" });
            DropIndex("dbo.PlanetHabitants", new[] { "Planet_Id" });
            DropTable("dbo.MoonPlanets");
            DropTable("dbo.PlanetHabitants");
            DropTable("dbo.Moons");
            DropTable("dbo.Planets");
            DropTable("dbo.Habitants");
        }
    }
}
