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
    public class ActivitiesModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public List<Activity> Activity { get; set; } = new();
        //public List<Activity> Activities { get; set; } = new List<Activity>();
        public string Html { get; private set; } = string.Empty;
        [BindProperty]
        public Activity NewActivity { get; set; } = new Activity();

        public ActivitiesModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task OnGetAsync()
        {
            await GetActivitiesAsync();
        }

        private async Task GetActivitiesAsync()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("http://145.93.56.185:5000/");

            var response = await client.GetAsync("/activities"); // URL van je API

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                Activity = JsonSerializer.Deserialize<List<Activity>>(json);
            }
        }
        

        public async Task<IActionResult> OnPostAsync()
        {
            await GetActivitiesAsync();
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("http://145.93.56.185:5000/");

            var response = await client.PostAsJsonAsync("/activities", NewActivity);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage(); // succes → herlaad pagina
            }

            ModelState.AddModelError(string.Empty, "Fout bij toevoegen activiteit.");
            return Page();
        }
    
    }
}
        
    
    
