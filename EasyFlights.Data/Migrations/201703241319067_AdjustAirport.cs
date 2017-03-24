namespace EasyFlights.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdjustAirport : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Flights", "DefaultFare", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Flights", "DefaultFare");
        }
    }
}
