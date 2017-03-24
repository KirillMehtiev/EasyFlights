namespace EasyFlights.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Unknown : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Airports", "TimeZoneOffset", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Airports", "TimeZoneOffset", c => c.Double(nullable: false));
        }
    }
}
