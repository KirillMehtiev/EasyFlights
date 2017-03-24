using System.Data.Entity.Migrations;

namespace EasyFlights.Data.Migrations
{ 
    public partial class ChangeAiportTimeZoneOffsetType : DbMigration
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
