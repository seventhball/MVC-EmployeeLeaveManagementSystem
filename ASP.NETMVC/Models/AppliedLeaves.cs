using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ASP.NETMVC.Models
{
    public class AppliedLeaves
    {
        [Key]
        public int ApplyId { get; set; }

        [ForeignKey("EmployeeLeaves")]
        public int EmployeeLeaveId { get; set; }
        public virtual EmployeeLeaves EmployeeLeaves{ get; set; }
        public int NoOfLeaves { get; set; }

        [DisplayName("From")]
        //     [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DisplayFormat(DataFormatString = "{dd MMM yyyy}")]
        public DateTime FromDate { get; set; }

        [DisplayName("To")]
        [DisplayFormat(DataFormatString = "{dd MMM yyyy}")]
    //    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime ToDate { get; set; }
        public DateTime? CreatedOn { get; set; }

    }
}

