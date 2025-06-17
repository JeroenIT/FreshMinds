using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Logging;
using studenthousing.Models;

namespace studenthousing.Pages.Shared
{
    public class SignUpModel : PageModel
{
    [BindProperty]
    public Student NewStudent { get; set; } = new Student();

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        // Hier zou je de student opslaan in de database
        // Bijvoorbeeld: _context.Students.Add(Student); _context.SaveChanges();

        return RedirectToPage("/Index"); // Of redirect naar login/dashboard
    }


}

}


