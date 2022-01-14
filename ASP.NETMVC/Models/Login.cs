using System.ComponentModel.DataAnnotations;

namespace ASP.NETMVC.Models
{
    public class Login
    {

        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required")]
        public string EmailId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}   
