using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;

namespace PadariaWeb.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public ICollection<Product> Products { get; set; }
        public List<ProductTicket> ProductTickets { get; set; }
        [JsonIgnore]
        public int CustomerId { get; set; }
        public LoyalCustomer Customer { get; set; }
        [JsonIgnore]
        public int PaymentMethodId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }


        public void AddProduct(ProductTicket Obj)
        {
            ProductTickets.Add(Obj);
        }

        public bool RemoveProduct(int Id)
        {
            var ticket = ProductTickets.Find(o => o.ProductId == Id);
            if (ticket == null)
                throw new Exception("Product not found.");
            return ProductTickets.Remove(ticket);
        }

    }
}
