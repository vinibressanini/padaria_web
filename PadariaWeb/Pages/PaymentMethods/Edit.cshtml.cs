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

namespace PadariaWeb.Pages.PaymentMethods
{
    public class EditModel : PageModel
    {
        private readonly PadariaWeb.Data.AppDbContext _context;

        public EditModel(PadariaWeb.Data.AppDbContext context)
        {
            _context = context;
        }


        
        [BindProperty]
        public PaymentPostRequestBody PaymentMethod { get; set; } = new();

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
            PaymentMethod.Id = paymentmethod.Id;
            PaymentMethod.Flag = paymentmethod.Flag;
            PaymentMethod.Name = paymentmethod.Name;
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

            PaymentMethod paymentmethod = new()
            {
                Id = PaymentMethod.Id,
                Name = PaymentMethod.Name,
                Flag = PaymentMethod.Flag,
            };

            _context.Attach(paymentmethod).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentMethodExists(PaymentMethod.Id))
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

        private bool PaymentMethodExists(int id)
        {
            return _context.PaymenyMethod.Any(e => e.Id == id);
        }
    }
}
