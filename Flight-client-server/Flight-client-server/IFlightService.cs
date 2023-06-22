using System.Linq.Expressions;

using Flight_client_server.Models;
using Flight_client_server.Models.Filters;
using Flights.DataAccess;

namespace Flight_client_server
{
    public interface IFlightService
    {
        public Task<BatchDataResult<FlightVM>> GetAllFlights();

        public Task<BatchDataResult<FlightVM>> GetFlights(Func<Flight, bool> filter);
        public Task<BatchDataResult<FlightVM>> GetFlights(Func<Flight, bool> filter, int take, int skip);

        public Task<string> CreateFlight(CreateFlightVM model);

        public Task EditFlight(UpdateFlightVM model);

        public Task DeleteFlight(string id);
    }
}
