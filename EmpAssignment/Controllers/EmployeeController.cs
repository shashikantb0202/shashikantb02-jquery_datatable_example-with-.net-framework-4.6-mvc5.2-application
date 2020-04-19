using EmpAssignment.BusinessLayer;
using EmpAssignment.Constants;
using EmpAssignment.Models;
using EmpAssignment.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace EmpAssignment.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Employees()
        {
            ViewBag.sucessMessage = Convert.ToString(TempData["sucessMessage"]);
            ViewBag.errorMessage = Convert.ToString(TempData["errorMessage"]);
            TempData["sucessMessage"] = "";
            TempData["errorMessage"] = "";
            return View();
        }

        public string getEmployeeList(DataTableFilter filter)
        {
            long totalCount = 0;
            EmployeeBL manager = new EmployeeBL();
            List<Employee> emps = manager.getEmployeeList(filter,out totalCount);
            StringBuilder sb = new StringBuilder();
            sb.Clear();
            sb.Append("{");
            sb.Append("\"sEcho\": ");
            sb.Append("\"\" ");
            sb.Append(",");
            sb.Append("\"iTotalRecords\": ");
            sb.Append(totalCount);
            sb.Append(",");
            sb.Append("\"iTotalDisplayRecords\": ");
            sb.Append(totalCount);
            sb.Append(",");
            sb.Append("\"aaData\": ");
            sb.Append(JsonConvert.SerializeObject(emps));
            sb.Append("}");
            return sb.ToString();

        }



        public ActionResult AddEmployee()
        {
            return View();
        }

        public ActionResult SaveEmployee(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                EmployeeBL manager = new EmployeeBL();
                bool result = manager.AddEmployee(model);
                if (result)
                {
                    TempData["sucessMessage"] = MsgConstant.EmployeeAddSuccess;
                }
                else
                {
                    TempData["errorMessage"] = MsgConstant.EmployeeAddError;
                }
                return RedirectToAction("Employees", "Employee");
            }
            return View("AddEmployee");
        }

        public ActionResult Delete(long EmployeeID)
        {
            EmployeeBL manager = new EmployeeBL();
          bool result=  manager.Delete(EmployeeID);
            if (result)
            {
                TempData["sucessMessage"] = MsgConstant.EmployeeDeleteSuccess;
            }
            else
            {
                TempData["errorMessage"] = MsgConstant.EmployeeDeleteError;
            }
            return RedirectToAction("Employees", "Employee");
        }
    }
}