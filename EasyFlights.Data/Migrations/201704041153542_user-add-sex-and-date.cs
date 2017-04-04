namespace EasyFlights.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class useraddsexanddate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationUsers", "Sex", c => c.Int(nullable: false));
            AddColumn("dbo.ApplicationUsers", "DateOfBirth", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApplicationUsers", "DateOfBirth");
            DropColumn("dbo.ApplicationUsers", "Sex");
        }
    }
}
