using System.Text.Json.Serialization;

namespace PadariaWeb.Models
{
    public class Product
    {
        public int Id { get; set; }
        public ICollection<ProductTicket> ProductTickets { get; set; }

        public string Name { get; set; } = "";
      
        private double _price;
        public double Price
        {
            get
            {
                return this._price;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Value can't be negative.");
                
                this._price = value;
            }
        }
    }
}
