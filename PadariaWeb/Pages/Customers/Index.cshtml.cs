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

namespace PadariaWeb.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private readonly CustomerRepostory _repo;

        public IndexModel(CustomerRepostory repo) => _repo = repo;
       
        public IList<LoyalCustomer> LoyalCustomer { get;set; } = default!;

        public async Task OnGetAsync()
        {
            LoyalCustomer = (List<LoyalCustomer>)await _repo.GetAll();
        }
    }
}
