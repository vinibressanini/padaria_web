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
    public class DetailsModel : PageModel
    {
        private readonly PadariaWeb.Data.AppDbContext _context;

        public DetailsModel(PadariaWeb.Data.AppDbContext context)
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

            var loyalcustomer = await _context.Customer
                .Include(c => c.Tickets)
                .ThenInclude(tic => tic.ProductTickets)
                .Include(c => c.Tickets)
                .ThenInclude(tic => tic.PaymentMethod)
                .FirstOrDefaultAsync(c => c.Id == id);

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


    }
}
