﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PadariaWeb.Data;
using PadariaWeb.DTOs;
using PadariaWeb.Models;

namespace PadariaWeb.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly PadariaWeb.Data.AppDbContext _context;

        public CreateModel(PadariaWeb.Data.AppDbContext context)
        {
            _context = context;
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

                _context.Product.Add(product);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
