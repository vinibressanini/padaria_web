namespace PadariaWeb.Models
{
    public class Product
    {
        public int Id { get; set; }
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
                else if (value.GetType() != typeof(double))
                {
                    throw new ArgumentException("Invalid Data. Please Inform a Number");
                }
                this._price = value;
            }
        }
    }
}
