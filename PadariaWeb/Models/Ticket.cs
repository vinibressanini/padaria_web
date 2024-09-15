namespace PadariaWeb.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        private List<ProductTicket> _productTickets = [];
        public List<ProductTicket> ProductTickets
        {
            get
            {
                return _productTickets;
            }
        }
        public Customer Customer { get; set; }
        public PaymentMethod PaymentMethod { get; set; }

        public double TotalValue() => ProductTickets.Sum(pt => pt.Value());

        public void AddProduct(ProductTicket Obj)
        {
            ProductTickets.Add(Obj);
        }

        public bool RemoveProduct(int Id)
        {
            var ticket = ProductTickets.Find(o => o.Id == Id);
            if (ticket == null)
                throw new Exception("Product not found.");
            return ProductTickets.Remove(ticket);
        }

        public void ClientPoints()
        {
            if (Customer is LoyalCustomer)
            {
                var loyal = (LoyalCustomer)Customer;
                loyal.CalculatePoints(TotalValue());
            }
        }
    }
}
