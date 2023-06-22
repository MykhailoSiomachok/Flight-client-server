using System;
using System.Collections.Generic;

namespace Flights.DataAccess;

public partial class Flight
{
    public string Id { get; set; }

    public string? FlightName { get; set; }

    public string? Description { get; set; }

    public long? SoldTicketsAmount { get; set; }

    public string? Route { get; set; }
}
