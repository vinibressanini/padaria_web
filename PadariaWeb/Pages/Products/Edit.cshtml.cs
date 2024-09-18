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

namespace PadariaWeb.Pages.Products
{
    public class EditModel : PageModel
    {
        private readonly ProductRepository _productRepository;

        public EditModel(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [BindProperty]
        public ProductPostRequstDTO Product { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

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
                Product.Id = product.Id;
                Product.Name = product.Name;
                Product.Price = product.Price;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                Product product = new() { Id = Product.Id, Name = Product.Name, Price = Product.Price };
                await _productRepository.Update(product);
            }
            catch (Exception)
            {
                if (!await ProductExists(Product.Id))
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

        private async Task<bool> ProductExists(int id)
        {
            var product = await _productRepository.GetById(id);
            return product != null;
        }
    }
}
