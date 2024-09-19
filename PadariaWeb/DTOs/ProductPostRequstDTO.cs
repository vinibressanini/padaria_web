using Microsoft.AspNetCore.Mvc.Formatters.Xml;
using PadariaWeb.Models;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace PadariaWeb.DTOs
{
    public class ProductPostRequstDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The name is required")]
        public string Name { get; set; } = "";
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "The price is required")]
        [Range(0,999999,ErrorMessage = "The Pprice must be greater than 0")]
        public double Price { get; set; }
    }
}
