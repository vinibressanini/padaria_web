namespace PadariaWeb.Models
{
    public class LoyalCustomer : Customer
    {

        private string _cpf;
        public string Cpf
        {
            get
            {
                return this._cpf;
            }

            set
            {
                if (value == null || value == "" || value.Length != 11)
                    throw new ArgumentException("Invalid Document. Please Enter a Valid One");
                this._cpf = value;
            }
        }
        public double Points { get; set; } = 0.0;

        public void CalculatePoints(double PurchaseTotalPrice)
        {
            Points += PurchaseTotalPrice * 0.10;
        }

    }
}
