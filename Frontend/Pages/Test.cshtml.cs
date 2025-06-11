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
    public class TestModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public List<Test> Test { get; set; } = new();
        public string Html { get; private set; } = string.Empty;

        public TestModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        
        public async Task OnGetAsync()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("http://145.93.56.185:5000/");

            var response = await client.GetAsync("/objects"); // URL van je API

            if (response.IsSuccessStatusCode)
            {
                string html = await response.Content.ReadAsStringAsync();
                Test = JsonSerializer.Deserialize<List<Test>>(html);
                //var json = await response.Content.ReadAsStringAsync();
                //Taken = JsonSerializer.Deserialize<List<TestModel>>(json, new JsonSerializerOptions
            }
    }
        
    }
}