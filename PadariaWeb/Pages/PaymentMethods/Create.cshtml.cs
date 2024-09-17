using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PadariaWeb.Data;
using PadariaWeb.DTOs;
using PadariaWeb.Models;

namespace PadariaWeb.Pages.PaymentMethods
{
    public class CreateModel : PageModel
    {
        private readonly PadariaWeb.Data.AppDbContext _context;

        public CreateModel(PadariaWeb.Data.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public PaymentPostRequestBody PaymentMethod { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            PaymentMethod paymentMenthod = new()
            {
                Name = PaymentMethod.Name,
                Flag = PaymentMethod.Flag
            };

            _context.PaymenyMethod.Add(paymentMenthod);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
