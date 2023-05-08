using System.Linq.Expressions;

using Flight_client_server.Models;

using Flights.DataAccess;

namespace Flight_client_server
{
    public interface IFlightService
    {
        public Task<BatchDataResult<FlightVM>> GetAllFlights();

        public Task<BatchDataResult<FlightVM>> GetFlights(Func<Flight, bool> filter);
        public Task<BatchDataResult<FlightVM>> GetFlights(Func<Flight, bool> filter, int take, int skip);

        public Task<Guid> CreateFlight(CreateFlightVM model);

        public Task EditFlight(UpdateFlightVM model);

        public Task DeleteFlight(int id);
    }
}
