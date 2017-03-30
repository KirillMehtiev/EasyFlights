using System;
using System.Collections.Generic;
using EasyFlights.DomainModel.Entities;
using EasyFlights.Engines.RouteBuilding;

namespace EasyFlights.Engines.Tests.RouteBuilding
{
    public partial class RouteBuilderTests
    {
        private RouteBuilder CreateTestObject()
        {
            return new RouteBuilder();
        }
    }
}
