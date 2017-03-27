﻿using System.Web.Http;
using Newtonsoft.Json.Serialization;
using Owin;

[assembly: Microsoft.Owin.OwinStartup(typeof(EasyFlights.Web.Startup))]

namespace EasyFlights.Web
{

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            HttpConfiguration config = GlobalConfiguration.Configuration;
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.UseDataContractJsonSerializer = false;
        }
    }
}
