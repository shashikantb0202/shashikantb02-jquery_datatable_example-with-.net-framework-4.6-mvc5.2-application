using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmpAssignment.ViewModels
{
    public class EmployeeViewModel
    {
        public long Id { get; set; }
        [Range(5, 50)]
        [Required(ErrorMessage = "*Age is required")]
        public int Age { get; set; }
        [Required(ErrorMessage = "*Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "*Marital Status is required")]
        public string MaritalStatus { get; set; }
        [Required(ErrorMessage = "*Salary is required")]
        [Range(0, 9999999999)]
        public double Salary { get; set; }
        [Required(ErrorMessage = "*Location is required")]

        public string Location { get; set; }

        public EmployeeViewModel()
        {

        }
    }
}