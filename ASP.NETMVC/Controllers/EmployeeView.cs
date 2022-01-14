using Microsoft.AspNetCore.Mvc;
using ASP.NETMVC.ViewModel;
using ASP.NETMVC.Data;
using ASP.NETMVC.Models;
using Microsoft.AspNetCore.Authorization;

namespace ASP.NETMVC.Controllers
{
    public class EmployeeView : Controller
    {
        private readonly ApplicationDbContext _db;
        public EmployeeView(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index(int EmployeeId)
        {
            var session = HttpContext.Session.GetString("EmployeeId");
            int value = Convert.ToInt32(session);
            if (session == null || string.IsNullOrWhiteSpace(session))
            {
                return RedirectToAction("Login", "Employee");
            }
            else
            {
                List<Employee> employeeList = _db.Employees.Where(x => x.EmployeeId == value).ToList();
                List<EmployeeLeaves> employeeLeaves = _db.EmployeeLeaves.Where(x => x.EmployeeId == value).ToList();
                List<AppliedLeaves> appliedLeaves = _db.AppliedEmpLeaves.Where(x => x.EmployeeLeaveId == value).ToList();

                var employeeLeaveHeader = from emp in employeeList
                                          join empLeav in employeeLeaves
                                          on emp.EmployeeId equals empLeav.EmployeeId
                                          select new EmployeeLeaveHeader
                                          {
                                              EmployeeId = emp.EmployeeId,
                                              firstName = emp.FirstName,
                                              LastName = emp.LastName,
                                              RemainingLeaves = empLeav.NoOfLeavesRemaining,
                                              TotalLeaves = empLeav.TotalNoOfLeaves,
                                              TotalAppliedLeaves = empLeav.NoOfLeavesTaken
                                          };
                var employeeLeaveDetail = appliedLeaves.Select(x => new EmployeeLeaveDetail()
                {
                    AppliedOn = x.CreatedOn,
                    FromDate = x.FromDate,
                    ToDate = x.ToDate,
                    NoOfLeave = x.NoOfLeaves
                }).ToList();

                var Data = new EmployeeViewModel();
                Data.employeeLeaveHeader = employeeLeaveHeader.FirstOrDefault();
                Data.employeeLeaveDetail = employeeLeaveDetail;
                return View(Data);
            }
        }

           [HttpPost]
        public IActionResult Save(AppliedLeaveModel appliedLeaveModel)
        {
            int EmployeeId = Convert.ToInt32(HttpContext.Session.GetString("EmployeeId"));
            if (ModelState.IsValid)
            {
                string days = (appliedLeaveModel.ToDate - appliedLeaveModel.FromDate).Days.ToString();
                var EmployeeLeaveData = _db.EmployeeLeaves.Single(c => c.EmployeeId == EmployeeId);
                AppliedLeaves appliedLeaves = new AppliedLeaves();
                if (EmployeeLeaveData.NoOfLeavesRemaining > 0 && EmployeeLeaveData.NoOfLeavesRemaining>=Convert.ToInt32(days))
                {               
                    appliedLeaves.EmployeeLeaveId = EmployeeId;
                    appliedLeaves.FromDate = appliedLeaveModel.FromDate;
                    appliedLeaves.ToDate = appliedLeaveModel.ToDate;
                    var fromDate = _db.AppliedEmpLeaves.Select(c => c.FromDate);
                    var toDate = _db.AppliedEmpLeaves.Select(c => c.ToDate);
                    appliedLeaves.NoOfLeaves = Convert.ToInt32(days);
                    EmployeeLeaveData.NoOfLeavesTaken = appliedLeaves.NoOfLeaves+EmployeeLeaveData.NoOfLeavesTaken;
                    EmployeeLeaveData.NoOfLeavesRemaining = EmployeeLeaveData.NoOfLeavesRemaining - appliedLeaves.NoOfLeaves;
                    appliedLeaves.CreatedOn = DateTime.Now;
                    _db.AppliedEmpLeaves.Add(appliedLeaves);
                    _db.SaveChanges();
                }
                return RedirectToAction("Index", "EmployeeView");
            }
            else
            {
                return RedirectToAction("Index", "AppliedLeaves");
            }
        }
    }
}
