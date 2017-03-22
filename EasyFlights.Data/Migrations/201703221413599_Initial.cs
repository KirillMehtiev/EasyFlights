using System;
using System.Data.Entity.Migrations;

namespace EasyFlights.Data.Migrations
{
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IdentityRoles",
                c => new
                    {
                        Id = c.String(false, 128),
                        Name = c.String(),
                        Description = c.String(),
                        Discriminator = c.String(false, 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRoles",
                c => new
                    {
                        RoleId = c.String(false, 128),
                        UserId = c.String(false, 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.IdentityRoles", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUsers",
                c => new
                    {
                        Id = c.String(false, 128),
                        FirstName = c.String(false),
                        LastName = c.String(false),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(false),
                        TwoFactorEnabled = c.Boolean(false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(false),
                        AccessFailedCount = c.Int(false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaims",
                c => new
                    {
                        Id = c.Int(false, true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogins",
                c => new
                    {
                        UserId = c.String(false, 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Aircrafts",
                c => new
                    {
                        Id = c.Int(false, true),
                        Model = c.String(false),
                        Capacity = c.Int(false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Airports",
                c => new
                    {
                        Id = c.Int(false, true),
                        City_Id = c.Int(false),
                        Title = c.String(false),
                        AirportCodeIata = c.String(false),
                        AirportCodeIcao = c.String(false),
                        TimeZoneOffset = c.Double(false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.City_Id)
                .Index(t => t.City_Id);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(false, true),
                        Country_Id = c.Int(false),
                        Name = c.String(false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.Country_Id)
                .Index(t => t.Country_Id);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(false, true),
                        Name = c.String(false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Flights",
                c => new
                    {
                        Id = c.Int(false, true),
                        Aircraft_Id = c.Int(false),
                        DepartureAirport_Id = c.Int(false),
                        DestinationAirport_Id = c.Int(false),
                        ScheduledDepartureTime = c.DateTime(false),
                        ScheduledArrivalTime = c.DateTime(false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Aircrafts", t => t.Aircraft_Id)
                .ForeignKey("dbo.Airports", t => t.DepartureAirport_Id)
                .ForeignKey("dbo.Airports", t => t.DestinationAirport_Id)
                .Index(t => t.Aircraft_Id)
                .Index(t => t.DepartureAirport_Id)
                .Index(t => t.DestinationAirport_Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(false, true),
                        User_Id = c.String(false, 128),
                        OrderDate = c.DateTime(false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.User_Id, true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Passengers",
                c => new
                    {
                        Id = c.Int(false, true),
                        FirstName = c.String(false),
                        LastName = c.String(false),
                        BirthDate = c.DateTime(false),
                        DocumentNumber = c.String(false),
                        AgeCategory = c.Int(false),
                        Sex = c.Int(false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Int(false, true),
                        Flight_Id = c.Int(false),
                        Passenger_Id = c.Int(false),
                        Order_Id = c.Int(false),
                        Fare = c.Decimal(false, 18, 2),
                        Discount = c.Decimal(false, 18, 2),
                        Seat = c.Int(false),
                        FlightClass = c.Int(false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Flights", t => t.Flight_Id)
                .ForeignKey("dbo.Passengers", t => t.Passenger_Id)
                .ForeignKey("dbo.Orders", t => t.Order_Id)
                .Index(t => t.Flight_Id)
                .Index(t => t.Passenger_Id)
                .Index(t => t.Order_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Tickets", "Passenger_Id", "dbo.Passengers");
            DropForeignKey("dbo.Tickets", "Flight_Id", "dbo.Flights");
            DropForeignKey("dbo.Orders", "User_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.Flights", "DestinationAirport_Id", "dbo.Airports");
            DropForeignKey("dbo.Flights", "DepartureAirport_Id", "dbo.Airports");
            DropForeignKey("dbo.Flights", "Aircraft_Id", "dbo.Aircrafts");
            DropForeignKey("dbo.Cities", "Country_Id", "dbo.Countries");
            DropForeignKey("dbo.Airports", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.IdentityUserRoles", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserLogins", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserClaims", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserRoles", "IdentityRole_Id", "dbo.IdentityRoles");
            DropIndex("dbo.Tickets", new[] { "Order_Id" });
            DropIndex("dbo.Tickets", new[] { "Passenger_Id" });
            DropIndex("dbo.Tickets", new[] { "Flight_Id" });
            DropIndex("dbo.Orders", new[] { "User_Id" });
            DropIndex("dbo.Flights", new[] { "DestinationAirport_Id" });
            DropIndex("dbo.Flights", new[] { "DepartureAirport_Id" });
            DropIndex("dbo.Flights", new[] { "Aircraft_Id" });
            DropIndex("dbo.Cities", new[] { "Country_Id" });
            DropIndex("dbo.Airports", new[] { "City_Id" });
            DropIndex("dbo.IdentityUserLogins", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaims", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "IdentityRole_Id" });
            DropTable("dbo.Tickets");
            DropTable("dbo.Passengers");
            DropTable("dbo.Orders");
            DropTable("dbo.Flights");
            DropTable("dbo.Countries");
            DropTable("dbo.Cities");
            DropTable("dbo.Airports");
            DropTable("dbo.Aircrafts");
            DropTable("dbo.IdentityUserLogins");
            DropTable("dbo.IdentityUserClaims");
            DropTable("dbo.ApplicationUsers");
            DropTable("dbo.IdentityUserRoles");
            DropTable("dbo.IdentityRoles");
        }
    }
}
