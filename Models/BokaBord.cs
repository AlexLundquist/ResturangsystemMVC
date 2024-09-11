using System.ComponentModel.DataAnnotations;

namespace ResturangsystemMVC.Models
{
    public class BokaBord
    {
        [Display(Name = "Antal")]
        [Required(ErrorMessage = "Måste ange Antal")]
        public int Antal { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Måste ange Email")]
        public string Email { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Måste ange Name")]
        public string Namn { get; set; }


        [Display(Name = "Datum")]
        [Required(ErrorMessage = "Måste ange Datum")]
        public DateTime Datum { get; set; }
    }
}
