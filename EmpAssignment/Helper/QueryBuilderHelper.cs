using EmpAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpAssignment.Helper
{
    public class QueryBuilderHelper
    {
        public string generateSearchQuery(DataTableFilter filter)
        {
            string query = "";
            if (!string.IsNullOrEmpty(filter.sSearch))
            {
                List<String> DBColumnsQuery = this.getDBColumnsLikeQuery(filter.sColumns, filter.sSearch);
                if (DBColumnsQuery.Count > 0)
                {
                    query = " WHERE ";
                }
                query = query + "(" + string.Join(" or ", DBColumnsQuery) + ")";
            }
            return query;
        }

        public string generateSortAndPaginationQuery(DataTableFilter filter)
        {
            string query = "";

            if (filter.iSortCol_0 > 0)
            {
                List<string> columns = filter.sColumns.Split(',').ToList(); ;

                string columnName = getDBColumnName(columns[filter.iSortCol_0]);
                if (!string.IsNullOrEmpty(columnName))
                {
                    query = query + " order by " + columnName + " " + filter.sSortDir_0;
                }
            }
            else
            {
                query = query + " order by EMPLOYEE.Id DESC";
            }
            query = query + " offset " + filter.iDisplayStart + " rows FETCH NEXT " + filter.iDisplayLength + " rows only";
            return query;
        }

        private List<string> getDBColumnsLikeQuery(string sColumns, string sSearch)
        {
            List<string> DBColumns = new List<string>();
            Array columns = sColumns.Split(',');
            foreach (string col in columns)
            {
                string DBCol = this.getDBColumnName(col);
                if (!string.IsNullOrEmpty(DBCol))
                {
                    DBColumns.Add(DBCol + " like '%'+@SearchString+'%'");
                }
            }
            return DBColumns;
        }

        private string getDBColumnName(string col)
        {
            string DBCol = "";
            switch (col)
            {  
                case "Id":
                    DBCol = "EMPLOYEE.Id";
                    break;
                case "Name":
                    DBCol = "EMPLOYEE.Name";
                    break;
                case "Age":
                    DBCol = "EMPLOYEE.Age";
                    break;
                case "MaritalStatus":
                    DBCol = "EMPLOYEE.MaritalStatus";
                    break;
                case "Salary":
                    DBCol = "EMPLOYEE.Salary";
                    break;
                case "Location":
                    DBCol = "EMPLOYEE.Location";
                    break;
               


            }
            return DBCol;
        }
    }
}