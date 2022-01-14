using Microsoft.AspNetCore.Mvc;
using ASP.NETMVC.Models;
using ASP.NETMVC.Data;
using Microsoft.AspNetCore.Authorization;

namespace ASP.NETMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _db;
        public EmployeeController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Welcome()
        {
            if (HttpContext.Session.GetString("EmployeeId") != null)
            {
                ViewBag.Username = HttpContext.Session.GetString("Username");
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Login loginData)
        {
            if (ModelState.IsValid)
            {
                var EmployeeData = _db.Employees.Where(x => x.EmailId == loginData.EmailId && x.Password == loginData.Password).FirstOrDefault();
                if (EmployeeData != null)
                {
                    HttpContext.Session.SetString("EmployeeId", EmployeeData.EmployeeId.ToString());
                    return RedirectToAction("Index", "EmployeeView", new { EmployeeId = EmployeeData.EmployeeId });
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Username or Password");
                    return RedirectToAction("Login", "Employee");
                }
            }
            else
            {
                return View();
            }
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Employee");
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee obj)
        {
            if (ModelState.IsValid)
            {
                obj.CreatedOn = DateTime.Now;
                _db.Employees.Add(obj);
                _db.SaveChanges();
                var employeeData = _db.Employees.Where(x => x.EmailId == obj.EmailId).FirstOrDefault();
                var data = new EmployeeLeaves();
                data.EmployeeId = employeeData.EmployeeId;
                data.TotalNoOfLeaves = 5;
                data.NoOfLeavesRemaining = 5;
                data.NoOfLeavesTaken = 0;
                data.CreatedOn = DateTime.Now;
                _db.EmployeeLeaves.Add(data);
                _db.SaveChanges();
                    HttpContext.Session.SetString("EmployeeId", data.EmployeeId.ToString());
                    return RedirectToAction("Index", "EmployeeView", new { EmployeeId = data.EmployeeId});
                
            }
            else
            {
                return View();
            }
        }
    }
}
