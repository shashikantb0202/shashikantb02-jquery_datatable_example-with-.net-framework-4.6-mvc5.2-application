using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpAssignment.Models
{
    public class DataTableFilter
    {
        public string sEcho { get; set; }
        public int iDisplayStart { get; set; }
        public int iDisplayLength { get; set; }
        public string sSearch { get; set; }
        public string sColumns { get; set; }
        public string sSortDir_0 { get; set; }
        public int iSortCol_0 { get; set; }

    }
}