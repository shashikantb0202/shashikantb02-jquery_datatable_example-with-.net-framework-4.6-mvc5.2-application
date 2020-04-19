using EmpAssignment.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace EmpAssignment.Models
{
    public class Employee:BaseModel
    {
       public int Age {get;set;} 
       public string MaritalStatus { get;set;}
        public double Salary { get;set;}
        public string Location { get;set;}

        public Employee()
        {

        }
        public Employee(DataRow row)
        {
            if (DatabaseHelper.isValidField(row,"Id"))
            {
                this.Id = row.getInt64ForKey("Id").Value;
            }
            if (DatabaseHelper.isValidField(row, "Age"))
            {
                this.Age = row.getInt32ForKey("Age").Value;
            }
            if (DatabaseHelper.isValidField(row, "MaritalStatus"))
            {
                this.MaritalStatus = row.getStringForKey("MaritalStatus");
            }
            if (DatabaseHelper.isValidField(row, "Name"))
            {
                this.Name = row.getStringForKey("Name");
            }
          
            if (DatabaseHelper.isValidField(row, "Location"))
            {
                this.Location = row.getStringForKey("Location");
            }
            if (DatabaseHelper.isValidField(row, "Salary"))
            {
                this.Salary = row.getDoubleForKey("Salary").Value;
            }
           
        }
    }
}