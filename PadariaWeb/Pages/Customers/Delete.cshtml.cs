using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PadariaWeb.Data;
using PadariaWeb.Models;

namespace PadariaWeb.Pages.Customers
{
    public class DeleteModel : PageModel
    {
        private readonly PadariaWeb.Data.AppDbContext _context;

        public DeleteModel(PadariaWeb.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public LoyalCustomer LoyalCustomer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loyalcustomer = await _context.Customer.FirstOrDefaultAsync(m => m.Id == id);

            if (loyalcustomer == null)
            {
                return NotFound();
            }
            else
            {
                LoyalCustomer = loyalcustomer;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loyalcustomer = await _context.Customer.FindAsync(id);
            if (loyalcustomer != null)
            {
                LoyalCustomer = loyalcustomer;
                _context.Customer.Remove(LoyalCustomer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
