using PadariaWeb.Models;
using System.ComponentModel.DataAnnotations;

namespace PadariaWeb.DTOs
{
    public class PaymentPostRequestBody
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The name is required")]
        public string Name { get; set; } = string.Empty;
        public string? Flag { get; set; } = string.Empty;

    }
}
