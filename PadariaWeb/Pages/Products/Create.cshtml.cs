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

namespace PadariaWeb.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly ProductRepository _productRepository;

        public CreateModel(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ProductPostRequstDTO Product { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                Product product = new()
                {
                    Name = Product.Name,
                    Price = Product.Price,
                };

                await _productRepository.Save(product); 

                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
