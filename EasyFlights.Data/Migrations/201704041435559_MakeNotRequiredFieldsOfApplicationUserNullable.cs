namespace EasyFlights.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeNotRequiredFieldsOfApplicationUserNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ApplicationUsers", "Sex", c => c.Int());
            AlterColumn("dbo.ApplicationUsers", "DateOfBirth", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ApplicationUsers", "DateOfBirth", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ApplicationUsers", "Sex", c => c.Int(nullable: false));
        }
    }
}
