using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASP.NETMVC.Models
{
    public class AppliedLeaveModel:IValidatableObject
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "The start date is required")]
        [Display(Name = "Start Date:")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime FromDate { get; set; }
        [Required(ErrorMessage = "The end date is required")]
        [Display(Name = "End Date:")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime ToDate { get; set; }
        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            if (ToDate < FromDate)
            {
                yield return new ValidationResult("EndDate must be greater than StartDate");
            }
        }

    }
}