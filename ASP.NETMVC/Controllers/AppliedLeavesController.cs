using Microsoft.AspNetCore.Mvc;
using ASP.NETMVC.Models;
using ASP.NETMVC.Data;
using System.Collections.Generic;

namespace ASP.NETMVC.Controllers
{
    public class AppliedLeavesController : Controller
    {
        private ApplicationDbContext _db;
        public AppliedLeavesController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index(int id)
        {
            AppliedLeaveModel appliedLeaveModel = new AppliedLeaveModel();
            return View(appliedLeaveModel);
        }
        public IActionResult Save(AppliedLeaveModel appliedLeaveModel)
        {
            //int EmployeeId = Convert.ToInt32(HttpContext.Session.GetString("EmployeeId"));
            //if (ModelState.IsValid)
            //{
            //    string days = (appliedLeaveModel.ToDate - appliedLeaveModel.FromDate).Days.ToString();
            //    AppliedLeaves appliedLeaves = new AppliedLeaves();
            //    appliedLeaves.EmployeeLeaveId = EmployeeId;
            //    appliedLeaves.FromDate = appliedLeaveModel.FromDate;
            //    appliedLeaves.ToDate = appliedLeaveModel.ToDate;
            //    appliedLeaves.NoOfLeaves = Convert.ToInt32(days);
            //    appliedLeaves.CreatedOn = DateTime.Now;
            //    _db.AppliedEmpLeaves.Add(appliedLeaves);
            //    _db.SaveChanges();
            //}
            return RedirectToAction("Index", "EmployeeView");
        }
    }
}
