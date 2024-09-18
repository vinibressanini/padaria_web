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

namespace PadariaWeb.Pages.PaymentMethods
{
    public class DeleteModel : PageModel
    {
        private readonly PaymentRepository _paymentRepository;

        public DeleteModel(PaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        [BindProperty]
        public PaymentMethod PaymentMethod { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentMethod = await _paymentRepository.GetById(id.Value);

            if (paymentMethod == null)
            {
                return NotFound();
            }
            else
            {
                PaymentMethod = paymentMethod;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentMethod = await _paymentRepository.GetById(id.Value);
            if (paymentMethod != null)
            {
                await _paymentRepository.Delete(id.Value);
            }

            return RedirectToPage("./Index");
        }
    }
}
