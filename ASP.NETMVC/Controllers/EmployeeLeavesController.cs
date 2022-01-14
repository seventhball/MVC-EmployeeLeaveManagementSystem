using Microsoft.AspNetCore.Mvc;
using ASP.NETMVC.Models;
using ASP.NETMVC.Data;
using System.Collections.Generic;
using System.Data.Entity;
using ASP.NETMVC.ViewModel;

namespace ASP.NETMVC.Controllers
{
    public class EmployeeLeavesController : Controller
    {
        private ApplicationDbContext _db;
        public EmployeeLeavesController(ApplicationDbContext db)
        {
            _db = db;
        }
  
        public ViewResult Index(int EmployeeId)
        {

//            var employeeLeaveEMp = _db.EmployeeLeaves.Include(c => c.Employee).ToList();
            // List<Employee> employeeList = _db.Employees.ToList();
            // List<EmployeeLeaves> employeeLeaves = _db.EmployeeLeaves.Where(emp => emp.EmployeeId == EmployeeId).ToList();
            // List<EmployeeLeaves> employeeLeaves = _db.EmployeeLeaves.ToList();
            //var ViewModel = from EmployeeName in _db.Employees
            //                join Emp in _db.EmployeeLeaves on EmployeeName.EmployeeId equals Emp.EmployeeId
            //                where Emp.EmployeeId == EmployeeId
            //                select new EmployeeViewModel { Employees = EmployeeName, EmployeeLeaves = Emp };
         //   EmployeeLeaves empl = _db.Employees.Find(EmployeeId);
            //if (EmployeeId!=null)
            //{
                
            //}
            return View();

        }
        public IActionResult Detail(int id)
        {
            var EmployeeLeaveDetail = _db.EmployeeLeaves.SingleOrDefault(c => c.EmployeeLeaveId == id);

            Employee employee = _db.Employees.FirstOrDefault(x => x.EmployeeId == id);

            if (EmployeeLeaveDetail == null)
            {
                return NotFound();
            }
            return View(EmployeeLeaveDetail);
        }
        public ActionResult Indexx()
        {
            //   List<Employee> employeeList = new List<Employee>();

            return View();
        }
    }
}
