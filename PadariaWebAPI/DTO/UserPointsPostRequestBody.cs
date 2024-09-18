using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace PadariaWebAPI.DTO
{
    public class UserPointsPostRequestBody
    {
        [Required(ErrorMessage = "UserID is required")]
        [Range(1,99999, ErrorMessage ="Enter a valid ID")]
        public int UserId { get; set; }
        [Required(ErrorMessage ="The PurchaseTotalPrice is required")]
        [Range(0,99999, ErrorMessage ="The price must be greater than 0")]
        public double PurchaseTotalPrice { get; set; }
    }
}
