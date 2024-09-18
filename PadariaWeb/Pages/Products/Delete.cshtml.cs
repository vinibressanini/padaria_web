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

namespace PadariaWeb.Pages.Products
{
    public class DeleteModel : PageModel
    {
        private readonly ProductRepository _productRepository;

        public DeleteModel(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [BindProperty]
        public Product Product { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productRepository.GetById(id.Value);

            if (product == null)
            {
                return NotFound();
            }
            else
            {
                Product = product;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productRepository.GetById(id.Value);
            if (product != null)
            {
                await _productRepository.Delete(id.Value);
            }

            return RedirectToPage("./Index");
        }
    }
}
