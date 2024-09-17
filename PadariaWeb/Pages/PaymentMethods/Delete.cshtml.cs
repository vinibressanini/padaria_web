using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PadariaWeb.Data;
using PadariaWeb.Models;

namespace PadariaWeb.Pages.PaymentMethods
{
    public class DeleteModel : PageModel
    {
        private readonly PadariaWeb.Data.AppDbContext _context;

        public DeleteModel(PadariaWeb.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PaymentMethod PaymentMethod { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentmethod = await _context.PaymenyMethod.FirstOrDefaultAsync(m => m.Id == id);

            if (paymentmethod == null)
            {
                return NotFound();
            }
            else
            {
                PaymentMethod = paymentmethod;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentmethod = await _context.PaymenyMethod.FindAsync(id);
            if (paymentmethod != null)
            {
                PaymentMethod = paymentmethod;
                _context.PaymenyMethod.Remove(PaymentMethod);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
