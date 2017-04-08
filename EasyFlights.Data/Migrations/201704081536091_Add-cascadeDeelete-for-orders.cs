namespace EasyFlights.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddcascadeDeeletefororders : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tickets", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Tickets", "Passenger_Id", "dbo.Passengers");
            AddForeignKey("dbo.Tickets", "Order_Id", "dbo.Orders", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Tickets", "Passenger_Id", "dbo.Passengers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "Passenger_Id", "dbo.Passengers");
            DropForeignKey("dbo.Tickets", "Order_Id", "dbo.Orders");
            AddForeignKey("dbo.Tickets", "Passenger_Id", "dbo.Passengers", "Id");
            AddForeignKey("dbo.Tickets", "Order_Id", "dbo.Orders", "Id");
        }
    }
}
