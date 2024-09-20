using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PadariaWeb.Data;
using PadariaWeb.Models;

namespace PadariaWeb.Pages.Tickets
{
    public class IndexModel : PageModel
    {
        private readonly PadariaWeb.Data.AppDbContext _context;

        public IndexModel(PadariaWeb.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<Ticket> Ticket { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Ticket = await _context.Ticket
                .Include(t => t.Customer)
                .Include(t => t.PaymentMethod).ToListAsync();
        }
    }
}
