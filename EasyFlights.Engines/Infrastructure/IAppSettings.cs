namespace EasyFlights.Engines.Infrastructure
{
    public interface IAppSettings
    {
        double MinAmountOfHoursToWaitFlight { get; }

        double MaxAmountOfHoursToWaitFlight { get; }
    }
}
