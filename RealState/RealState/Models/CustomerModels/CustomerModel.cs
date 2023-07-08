using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace RealState.Models.CustomerModels
{
    public class CustomerModel
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Phone Number is required")]
        public string Phone { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Adress is required")]
        public string Adress{get; set;}
    }
}
