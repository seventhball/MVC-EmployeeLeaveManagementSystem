using ASP.NETMVC.Models;
using System.ComponentModel.DataAnnotations;

namespace ASP.NETMVC.ViewModel
{
    public class EmployeeViewModel
    {
        //public Employee Employees { get; set; }
        //public EmployeeLeaves EmployeeLeaves { get; set; } 
        //public AppliedLeaves AppliedLeaves { get; set; }
        public EmployeeLeaveHeader employeeLeaveHeader { get; set; } = new();
        public List<EmployeeLeaveDetail> employeeLeaveDetail { get; set; } = new();

    }
    public class EmployeeLeaveHeader
    {
        public int EmployeeId { get; set; }
        public string firstName { get; set; }
        public string LastName { get; set; }
        public int TotalLeaves { get; set; }
        public int RemainingLeaves { get; set; }
        public int TotalAppliedLeaves { get; set; }

    }
    public class EmployeeLeaveDetail
    {
     //   public int ApplyId { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime? FromDate { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime? ToDate { get; set; }
        public int NoOfLeave { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime? AppliedOn { get; set; }

    }

}
