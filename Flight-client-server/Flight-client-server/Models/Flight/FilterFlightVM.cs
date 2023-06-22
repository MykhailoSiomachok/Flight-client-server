using Flight_client_server.Models.Interfaces;

namespace Flight_client_server.Models
{
    public class FilterFlightVM: IFilterModel
    {
         public string? Id { get; set; }

        public string? FlightName { get; set; }

        public string? Description { get; set; }

        public int? SoldTicketsAmount { get; set; }

        public List<string>? Route { get; set; }
    }
}
