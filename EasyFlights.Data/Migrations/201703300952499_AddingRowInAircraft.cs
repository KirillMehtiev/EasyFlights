namespace EasyFlights.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingRowInAircraft : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Aircrafts", "Row", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Aircrafts", "Row");
        }
    }
}
