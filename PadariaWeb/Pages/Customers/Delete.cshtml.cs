using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PadariaWeb.Data;
using PadariaWeb.Models;
using PadariaWeb.Repositories;

namespace PadariaWeb.Pages.Customers
{
    public class DeleteModel : PageModel
    {
        private readonly CustomerRepostory _repo;

        public DeleteModel(CustomerRepostory repo) => _repo = repo;

        [BindProperty]
        public LoyalCustomer LoyalCustomer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loyalcustomer = await _repo.GetById((int)id);

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

            try
            {
                await _repo.Delete((int)id);
                return RedirectToPage("./Index");
            } catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }
    }
}
