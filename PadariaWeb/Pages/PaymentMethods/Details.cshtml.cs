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
    public class DetailsModel : PageModel
    {
        private readonly PaymentRepository _paymentRepository;

        public DetailsModel(PaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

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
    }
}
