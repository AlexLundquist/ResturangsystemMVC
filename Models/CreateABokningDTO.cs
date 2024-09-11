namespace ResturangsystemMVC.Models
{
    public class CreateABokningDTO
    {
        public string name { get; set; }
        public string email { get; set; }
        public int antal { get; set; }
        public int bordsnummer { get; set; }
        public DateTime datum { get; set; }
    }
}
