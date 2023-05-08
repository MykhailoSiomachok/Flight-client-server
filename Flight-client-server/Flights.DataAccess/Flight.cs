namespace Flights.DataAccess
{
    public class Flight
    {
        public Guid Id { get; set; }

        public string FlightName { get; set; }

        public string Description { get; set; }

        public int SoldTicketsAmount { get; set; }

        /// <summary>
        /// Due to using SQL db this will be a JSON, which should be parsed into list of cities in VM model and vice versa
        /// </summary>
        public string Route { get; set; }
    }
}
