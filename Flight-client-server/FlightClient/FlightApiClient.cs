namespace FlightApiClient;

public class FlightApiClient
{
    private const string _baseUrl = "http://localhost:5196";
    public async Task GetFlightsAsync()
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Get, $"{_baseUrl}/api/flights");
        var response = await client.SendAsync(request);
        Console.WriteLine(await response.Content.ReadAsStringAsync());
    }

    public async Task CreateFlightAsync()
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Post, $"{_baseUrl}/api/flights");
        var content = new StringContent("{\n    \"flightName\": \"consectetur non magna\",\n    \"description\": \"qui in sunt do\",\n    \"soldTicketsAmount\": 7971515,\n    \"route\": [\n        \"ea pariatur Duis velit\",\n        \"adipisicing ea\"\n    ]\n}", null, "application/json");
        request.Content = content;
        var response = await client.SendAsync(request);
        Console.WriteLine(await response.Content.ReadAsStringAsync());
    }

    public async Task UpdateFlightAsync()
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Put, $"{_baseUrl}/api/flights");
        var content = new StringContent("{\n    \"id\": \"00000000-0000-0000-0000-000000000000\",\n    \"flightName\": \"sed consectetur\",\n    \"description\": \"et dolor non proident\",\n    \"soldTicketsAmount\": 58524624,\n    \"route\": [\n        \"amet adipisicing aliqua\",\n        \"ut consequat \"\n    ]\n}", null, "application/json");
        request.Content = content;
        var response = await client.SendAsync(request);
        Console.WriteLine(await response.Content.ReadAsStringAsync());
    }

    public async Task DeleteFlightAsync()
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Delete, $"{_baseUrl}/api/flights?flightId=94e6419b-75d1-799a-6eb5-2f6b4175cb17");
        var response = await client.SendAsync(request);
        Console.WriteLine(await response.Content.ReadAsStringAsync());
    }

    public async Task GetFilteredFlightAsync()
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Get, $"{_baseUrl}/api/flights/filter?Id=94e6419b-75d1-799a-6eb5-2f6b4175cb17&FlightName=qui nostrud minim Ut&Description=qui nostrud minim Ut&SoldTicketsAmount=-33347083&Route=esse consectetur reprehenderit pariatur&Route=est et amet");
        var response = await client.SendAsync(request);
        Console.WriteLine(await response.Content.ReadAsStringAsync());
    }
}