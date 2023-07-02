using Muneeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Muneeb.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            EmployeeDB db = new EmployeeDB();
            List<Employee> obj = db.GetEmployees();

            return View(obj);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            if (ModelState.IsValid == true)
            {
                EmployeeDB context = new EmployeeDB();
              bool check =   context.AddEmployee(emp);
                if (check == true)
                {
                    TempData["InsertMessage"] = "Data has been submited";
                    ModelState.Clear();
                    return RedirectToAction("Index");

                }
            }

            return View();
        }

        public ActionResult Edit(int Id)
        {
            EmployeeDB context = new EmployeeDB();
            var row = context.GetEmployees().Find(model => model.Id == Id);

            return View(row);
        }

        [HttpPost]
        public ActionResult Edit(int Id, Employee emp)
        {
            if (ModelState.IsValid == true) 
            {
                EmployeeDB context = new EmployeeDB();
                bool check = context.UpdateEmployee(emp);
                if (check == true)
                {
                    TempData["UpdateMessage"] = "Data has been Updated";
                    ModelState.Clear();
                    return RedirectToAction("Index");

                }

              
        }
            return View();
        }
}