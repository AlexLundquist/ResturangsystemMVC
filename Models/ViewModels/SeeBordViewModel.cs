using ResturangsystemMVC.Models.DTO;

namespace ResturangsystemMVC.Models.ViewModels
{
    public class SeeBordViewModel
    {
        public BokaBord BokaBord { get; set; }
        public List<AvailableTablesDTO> AvailableTables { get; set; }
    }
}
