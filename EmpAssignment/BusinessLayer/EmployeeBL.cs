using EmpAssignment.DataAccessLayer;
using EmpAssignment.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using EmpAssignment.ViewModels;

namespace EmpAssignment.BusinessLayer
{
    public class EmployeeBL
    {
        public List<Employee> getEmployeeList(DataTableFilter filter,out long totalCount)
        {
            EmployeeDA DAmanager = new EmployeeDA();
            totalCount = 0;
           DataSet  ds= DAmanager.getEmployeeList(filter);
            List<Employee> emps = new List<Employee>();
            if (ds!=null && ds.Tables.Count>0&& ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in  ds.Tables[0].Rows)
                {
                    emps.Add(new Employee(row));
                }
            }
            if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            {
                totalCount = Convert.ToInt64(ds.Tables[1].Rows[0]["COUNT"]);
            }
            return emps;
        }

        internal bool Delete(long employeeID)
        {
            EmployeeDA DAmanager = new EmployeeDA();
          
            return  DAmanager.Delete(employeeID);
           
        }

        internal bool AddEmployee(EmployeeViewModel model)
        {
            EmployeeDA DAmanager = new EmployeeDA();
            Employee emp = new Employee();
            emp.Age = model.Age;
            emp.Name = model.Name;
            emp.Salary = model.Salary;
            emp.MaritalStatus = model.MaritalStatus;
            emp.Location = model.Location;
            return DAmanager.AddEmployee(emp);
        }
    }
}