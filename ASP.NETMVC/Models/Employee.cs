using System.ComponentModel.DataAnnotations;

namespace ASP.NETMVC.Models
{
    public class Employee
    {

        [Key]
        public int EmployeeId { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public string EmailId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Need min 6 character")]
        public string Password { get; set; }
        public DateTime? CreatedOn { get; set; }   
   //     public virtual ICollection<EmployeeLeaves> EmployeeLeaves { get; set; }

    } 
}
