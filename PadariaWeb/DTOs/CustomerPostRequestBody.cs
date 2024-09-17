using PadariaWeb.Models;
using System.ComponentModel.DataAnnotations;

namespace PadariaWeb.DTOs
{
    public class CustomerPostRequestBody
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The name is required")]
        public string Name { get; set; } = "";
        [Required(ErrorMessage = "The customer CPF is required")]
        [StringLength(11,MinimumLength =11,ErrorMessage = "The CPF must have only 11 numbers")]
        public string Cpf { get; set; }
               
    }
}
