using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
    using EasyFlights.Services.Interfaces;

namespace EasyFlights.Web.ApiControllers
{

    public class RoutesController : ApiController
    {
        private readonly ISearchingService searchingService;

        public RoutesController(ISearchingService searchingService)
        {
            this.searchingService = searchingService;
        }

        // GET api/<controller>
        public IEnumerable<string> Get(string departureAirport, string destinationAirport, DateTime departureTime)
        {
            return new string[] { "value1", "value2" };
        }
        
    }
}