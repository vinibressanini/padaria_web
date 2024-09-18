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
using PadariaWeb.Repositories;

namespace PadariaWeb.Pages.Customers
{
    public class CreateModel : PageModel
    {
        private readonly CustomerRepostory _repo;

        public CreateModel(CustomerRepostory repo) => _repo = repo;
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CustomerPostRequestBody LoyalCustomer { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    LoyalCustomer customer = new()
                    {
                        Name = LoyalCustomer.Name,
                        Cpf = LoyalCustomer.Cpf,
                    };

                    await _repo.Save(customer);

                    return RedirectToPage("./Index");
                }
                catch (Exception ex)
                {
                    return Page();
                }
            }
            return Page();
        }
    }
}
