using System.Net.Http;
using System.Threading.Tasks;

public class ApiService
{
    private readonly HttpClient _httpClient;

    // Zorg ervoor dat je HttpClient injecteert via Dependency Injection (DI)
    public ApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // Haal data van de API op (GET-verzoek)
    public async Task<string> GetApiData()
    {
        // Vervang 'http://localhost:5000' door je daadwerkelijke API-URL
        var response = await _httpClient.GetAsync("http://localhost:5000/");

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadAsStringAsync(); // Retourneer de data van de API
        }
        else
        {
            return "Fout bij het ophalen van gegevens.";
        }
    }
}
