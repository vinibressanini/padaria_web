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

namespace PadariaWeb.Pages.PaymentMethods
{
    public class EditModel : PageModel
    {
        private readonly PaymentRepository _paymentRepository;

        public EditModel(PaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }



        [BindProperty]
        public PaymentMethod PaymentMethod { get; set; } = new();

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

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                await _paymentRepository.Update(PaymentMethod);
            }
            catch (Exception)
            {
                if (!await PaymentMethodExists(PaymentMethod.Id))
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

        private async Task<bool> PaymentMethodExists(int id)
        {
            var paymentMethod = await _paymentRepository.GetById(id);
            return paymentMethod != null;
        }
    }
}
