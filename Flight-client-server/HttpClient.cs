using System;
using System.Threading.Tasks;

using System.Net.Http

public class Class1
{
	public Class1()
	{
		
	}

	public async Task A()
	{
        var client = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Get, "//api/flights");
        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();
        Console.WriteLine(await response.Content.ReadAsStringAsync());
    }
}
