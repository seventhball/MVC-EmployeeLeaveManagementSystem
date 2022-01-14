using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.NETMVC.Models
{
    public class EmployeeLeaves
    {
        [Key]
        public int EmployeeLeaveId { get; set; }

        [ForeignKey("Employee")]

        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public int TotalNoOfLeaves { get; set; }
        public int NoOfLeavesTaken { get; set; }
        public int NoOfLeavesRemaining { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UdatedOn { get; set; }
        //  public virtual ICollection<Employee> Employees { get; set;}

    }
}

