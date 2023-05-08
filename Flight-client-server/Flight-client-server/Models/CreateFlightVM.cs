namespace Flight_client_server.Models
{
    public class CreateFlightVM
    {
        public string FlightName { get; set; }

        public string Description { get; set; }

        public int SoldTicketsAmount { get; set; }

        public List<string> Route { get; set; }
    }
}
