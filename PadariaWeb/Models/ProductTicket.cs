namespace PadariaWeb.Models
{
    public class ProductTicket
    {
        public int Id { get; set; }
        public Product Product { get; set; }

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

        public double Value()
        {
            return Product.Price * Quantity;
        }
    }
}
