using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using PadariaWeb.Models;

namespace PadariaWeb.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Ticket>()
                .HasMany(x => x.ProductTickets)
                .WithOne(x => x.Ticket)
                .HasForeignKey(x => x.TicketId);

            modelBuilder.Entity<Ticket>()
                .HasMany(e => e.Products)
                .WithMany(e => e.Tickets)
                .UsingEntity<ProductTicket>();

            //l => l.HasOne(typeof(Tag)).WithMany().HasForeignKey("TagsId").HasPrincipalKey(nameof(Tag.Id)),
            //r => r.HasOne(typeof(Post)).WithMany().HasForeignKey("PostsId").HasPrincipalKey(nameof(Post.Id))

            modelBuilder.Entity<Ticket>()
                .HasOne(x => x.Customer)
                .WithMany(x => x.Tickets)
                .HasForeignKey(x => x.CustomerId);

            modelBuilder.Entity<Ticket>()
                .HasOne(x => x.PaymentMethod)
                .WithMany(x => x.Tickets)
                .HasForeignKey(x => x.PaymentMethodId);

            base.OnModelCreating(modelBuilder);

        }

        public DbSet<LoyalCustomer> Customer { get; set; } = default!;
        public DbSet<ProductTicket> ProductTicket { get; set; } = default!;
        public DbSet<Product> Product { get; set; } = default!;
        public DbSet<Ticket> Ticket { get; set; } = default!;
        public DbSet<PaymentMethod> PaymenyMethod { get; set; } = default!;
    }
}
