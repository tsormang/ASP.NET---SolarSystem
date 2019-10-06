namespace Super_Solar_System.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Images : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Planets", "Image", c => c.String());
            AddColumn("dbo.Moons", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Moons", "Image");
            DropColumn("dbo.Planets", "Image");
        }
    }
}
