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

namespace PadariaWeb.Pages.PaymentMethods
{
    public class CreateModel : PageModel
    {
        private readonly PaymentRepository _paymentRepository;

        public CreateModel(PaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public PaymentPostRequestBody PaymentMethod { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                PaymentMethod paymentMethod = new()
                {
                    Name = PaymentMethod.Name,
                    Flag = PaymentMethod.Flag,
                };

                await _paymentRepository.Save(paymentMethod);

                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
