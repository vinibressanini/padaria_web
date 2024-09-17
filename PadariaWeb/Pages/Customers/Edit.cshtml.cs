using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PadariaWeb.Data;
using PadariaWeb.DTOs;
using PadariaWeb.Models;

namespace PadariaWeb.Pages.Customers
{
    public class EditModel : PageModel
    {
        private readonly PadariaWeb.Data.AppDbContext _context;

        public EditModel(PadariaWeb.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CustomerPostRequestBody LoyalCustomer { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loyalcustomer =  await _context.Customer.FirstOrDefaultAsync(m => m.Id == id);
            if (loyalcustomer == null)
            {
                return NotFound();
            }
            LoyalCustomer.Id = loyalcustomer.Id ;
            LoyalCustomer.Name = loyalcustomer.Name;
            LoyalCustomer.Cpf = loyalcustomer.Cpf;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            LoyalCustomer customer = new()
            {
                Id = LoyalCustomer.Id,
                Name = LoyalCustomer.Name,
                Cpf = LoyalCustomer.Cpf,
            };

            _context.Attach(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoyalCustomerExists(LoyalCustomer.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool LoyalCustomerExists(int id)
        {
            return _context.Customer.Any(e => e.Id == id);
        }
    }
}
