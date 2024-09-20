using System.Text.Json.Serialization;

namespace PadariaWeb.Models
{
    public class PaymentMethod
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Flag { get; set; } = string.Empty;

        private string _fullName;

        public string FullName
        {
            get
            {
                return this.Name + " - " + this.Flag;
            }

            set
            {
                this._fullName = value;
            }
        }
        [JsonIgnore]
        public ICollection<Ticket> Tickets { get; set; }
    }
}
