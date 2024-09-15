namespace PadariaWeb.Models
{
    public class PaymentMethod
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Flag { get; set; } = string.Empty;
    }
}
