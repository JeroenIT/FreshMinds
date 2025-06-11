using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace studenthousing.Pages
{
    public class Activiteiten : PageModel
    {
        private readonly ILogger<Activiteiten> _logger;

        public Activiteiten(ILogger<Activiteiten> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}