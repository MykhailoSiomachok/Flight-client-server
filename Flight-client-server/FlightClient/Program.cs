var flightApiClient = new FlightApiClient.FlightApiClient();


await flightApiClient.GetFilteredFlightAsync();
await flightApiClient.GetFlightsAsync();
await flightApiClient.CreateFlightAsync();
await flightApiClient.UpdateFlightAsync();
await flightApiClient.DeleteFlightAsync();