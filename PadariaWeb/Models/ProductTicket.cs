using System.Text.Json.Serialization;

namespace PadariaWeb.Models
{
    public class ProductTicket
    {
	
		public int TicketId { get; set; }
        [JsonIgnore]
        public Ticket Ticket { get; set; }
        [JsonIgnore]
		public Product Product { get; set; }
        public int ProductId { get; set; }

        private int _quantity;
        public double ProductCurrentPrice { get; set; }
        public int Quantity
        {
            get { return this._quantity; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Quantity can't be zero or negative.");
                this._quantity = value;
            }
        }

        public double Value() => this._quantity * ProductCurrentPrice;

    }
}
