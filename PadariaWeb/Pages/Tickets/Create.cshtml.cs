using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PadariaWeb.Data;
using PadariaWeb.Models;

namespace PadariaWeb.Pages.Tickets
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
        ViewData["PaymentMethod"] = new SelectList(_context.PaymenyMethod, "Id", "FullName");
        ViewData["Products"] = new SelectList(_context.Product, "Id", "Name");

            return Page();
        }

        [BindProperty]
        public Ticket Ticket { get; set; } = default!;

        [BindProperty]
        public int Quantity { get; set; }



        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {

            var customer = await _context.Customer.FirstOrDefaultAsync(c => c.Cpf == Ticket.Customer.Cpf);
            
            
            if (customer == null)
            {
                ModelState.AddModelError("Ticket.Customer.Cpf", "Customer not found.");
                return Page();
            }

            Ticket.Customer = customer;

            


            _context.Ticket.Add(Ticket);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
