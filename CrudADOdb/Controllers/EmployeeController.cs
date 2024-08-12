using CrudADOdb.Data;
using CrudADOdb.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudADOdb.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeDataAccessLayer _context;
        public EmployeeController()
        {
            _context = new EmployeeDataAccessLayer();
        }

        public IActionResult Index()
        {
            List<Employees> emps = _context.getAllEmployees();
            return View(emps);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employees obj)
        {
            try
            {
                _context.addEmployee(obj);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Edit(int id)
        {

            return View();
        }

        public IActionResult Delete(int id)
        {
            return View();
        }


        public IActionResult Details()
        {
            return View();
        }


    }
}
