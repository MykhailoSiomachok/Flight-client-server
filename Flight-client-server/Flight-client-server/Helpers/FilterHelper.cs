using System.Text.Json;

using Flight_client_server.Models;

using Flights.DataAccess;

namespace Flight_client_server.Helpers
{
    public static class FilterHelper
    {
        private static bool IsValidFilter(FilterFlightVM model)
        {
            var IsValid = true;

            //Todo: Add validation context
            return IsValid;
        }



        public static Func<Flight, bool> ParseFlightFilter(FilterFlightVM model)
        {
            if (model is null || !IsValidFilter(model))
            {
                return (_) => false;
            }

            Func<Flight, bool> filter = (_) => true;

            if (model.Id.HasValue)
            {
                filter = (x) => x.Id == model.Id && filter(x);
            }

            if (!string.IsNullOrEmpty(model.FlightName))
            {
                filter = (x) => x.FlightName.Contains(model.FlightName) && filter(x);
            }

            if (!string.IsNullOrEmpty(model.Description))
            {
                filter = (x) => x.FlightName.Contains(model.Description) && filter(x);
            }

            if (model.SoldTicketsAmount.HasValue)
            {
                filter = (x) => x.SoldTicketsAmount == model.SoldTicketsAmount && filter(x);
            }

            if (model.Route is not null && model.Route.Any())
            {
                filter = (x) =>
                {
                    var IsSubroute = false;
                    var parsedRoute = JsonSerializer.Deserialize<List<string>>(x.Route);
                    if (model.Route.Except(parsedRoute).Any())
                    {
                        IsSubroute = true;
                    }

                    return IsSubroute && filter(x);
                };
            }

            return filter;
        }

    }
}
