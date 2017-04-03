using System;
using System.Configuration;
using System.Globalization;

namespace EasyFlights.Engines.Infrastructure
{
    public class AppSettings : IAppSettings
    {
        public double MaxAmountOfHoursToWaitFlight
        {
            get
            {
                string strValue = this.GetSetting("maxAmountOfHoursToWaitFlight");
                return Convert.ToDouble(strValue, CultureInfo.InvariantCulture);
            }
        }

        public double MinAmountOfHoursToWaitFlight
        {
            get
            {
                string strValue = this.GetSetting("minAmountOfHoursToWaitFlight");
                return Convert.ToDouble(strValue, CultureInfo.InvariantCulture);
            }
        }

        private string GetSetting(string settingName)
        {
            return ConfigurationManager.AppSettings[settingName];
        }
    }
}
