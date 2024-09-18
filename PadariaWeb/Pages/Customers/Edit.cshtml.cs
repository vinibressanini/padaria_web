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
using PadariaWeb.Repositories;

namespace PadariaWeb.Pages.Customers
{
    public class EditModel : PageModel
    {
        private readonly CustomerRepostory _repo;
        public EditModel(CustomerRepostory repo) => _repo = repo;

        [BindProperty]
        public CustomerPostRequestBody LoyalCustomer { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loyalcustomer =  await _repo.GetById((int)id);
            if (loyalcustomer == null)
            {
                return NotFound();
            }
            LoyalCustomer.Id = loyalcustomer.Id ;
            LoyalCustomer.Name = loyalcustomer.Name;
            LoyalCustomer.Cpf = loyalcustomer.Cpf;
            return Page();
        }

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

            _repo.Update(customer);

            return RedirectToPage("./Index");
        }

    }
}
