using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System.ComponentModel.DataAnnotations;

namespace ResturangsystemMVC.Models
{
    public class Meny
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Namn måste anges")]
        [Display(Name = "Namn på rätt")]
        public string Namn { get; set; }

        [Required(ErrorMessage = "Pris måste anges")]
        [Display(Name = "Pris")]
        [Range(1, 1000, ErrorMessage = "Priset måste vara mellan 1 och 1000")]
        public decimal Pris { get; set; }

    }
}
