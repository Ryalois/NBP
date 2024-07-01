using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

class Program
{
    private static readonly HttpClient client = new HttpClient();
    private static String url = "https://api.freecurrencyapi.com/v1/latest?apikey=fca_live_7h6EYPDBbxvVuvf58F0kIloodKWqX79N1PhICCWW";
    static async Task Main(String[] args)
    {
        String read = Console.ReadLine();
        Double val = Double.Parse(read);
        try
        {
            HttpResponseMessage res = await client.GetAsync(url);
            res.EnsureSuccessStatusCode();

            String responseBody = await res.Content.ReadAsStringAsync();
            JsonDocument json = JsonDocument.Parse(responseBody);

            Double pln = json.RootElement.GetProperty("data").GetProperty("PLN").GetDouble();

            Console.WriteLine(Math.Round(val/pln*100)/100);
        }
        catch(Exception e)
        {
            Console.WriteLine(e);
        }ss
    }
}