namespace EasyFlights.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class onetooneremoved : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Flights", new[] { "Aircraft_Id" });
            AlterColumn("dbo.Flights", "Aircraft_Id", c => c.Int());
            CreateIndex("dbo.Flights", "Aircraft_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Flights", new[] { "Aircraft_Id" });
            AlterColumn("dbo.Flights", "Aircraft_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Flights", "Aircraft_Id");
        }
    }
}
