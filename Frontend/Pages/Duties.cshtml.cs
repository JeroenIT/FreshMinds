using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using studenthousing.Models;


namespace studenthousing.Pages
{
    public class DutiesModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public List<Duty> Duty { get; set; } = new();
        //public List<Duty> Duties { get; set; } = new List<Duty>();
        public string Html { get; private set; } = string.Empty;
        [BindProperty]
        public Duty NewDuty { get; set; } = new Duty();

        public DutiesModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task OnGetAsync()
        {
            await GetDutiesAsync();
        }
        private async Task GetDutiesAsync()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("http://127.0.0.1:5000/");

            var response = await client.GetAsync("/duties"); // URL van je API

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                Duty = JsonSerializer.Deserialize<List<Duty>>(json);
                
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await OnGetAsync(); // herlaad lijst bij fouten
                return Page();
            }

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("http://127.0.0.1:5000/");

            var response = await client.PostAsJsonAsync("/duties", NewDuty);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage(); // succes → herlaad pagina
            }

            ModelState.AddModelError(string.Empty, "Fout bij toevoegen activiteit.");
            await OnGetAsync();
            return Page();
        }
    
    
    }
}