using EmpAssignment.Helper;
using EmpAssignment.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace EmpAssignment.DataAccessLayer
{
    public class EmployeeDA
    {

        internal DataSet getEmployeeList(DataTableFilter filter)
        {
            QueryBuilderHelper QBManager = new QueryBuilderHelper();
            string searchQuery = string.Empty;
            if (!string.IsNullOrEmpty(filter.sSearch))
            {
                searchQuery = QBManager.generateSearchQuery(filter);
            }

            string SortAndPaginationquery = QBManager.generateSortAndPaginationQuery(filter);
            DataSet ds = null;

            DatabaseManager DBManager = DatabaseManager.sharedDatabaseManagerinstance;
            DSQuery dbquery = new DSQuery();
            dbquery.query = " SELECT Id,Name,Age,Salary,MaritalStatus,Location FROM Employee EMPLOYEE";
            dbquery.query = dbquery.query + " " + searchQuery + " " + SortAndPaginationquery + "; ";
            dbquery.query = dbquery.query + (getCountDBQuery() + searchQuery);
            dbquery.parameters.Add("SearchString", filter.sSearch);
            ds = DBManager.internalExecuteSelectQueryAndReturnDataSet(dbquery);
            return ds;
        }

        internal bool Delete(long employeeID)
        {
            bool result = false;
            DatabaseManager DBManager = DatabaseManager.sharedDatabaseManagerinstance;
            DSQuery dbquery = new DSQuery();
            dbquery.query = " DELETE FROM Employee where Id=@EmployeeID";
            dbquery.parameters.Add("EmployeeID", employeeID);
            result = DBManager.internalExecute(dbquery);
            return result;
        }

        internal bool AddEmployee(Employee emp)
        {
            bool result = false;
            DatabaseManager DBManager = DatabaseManager.sharedDatabaseManagerinstance;
            DSQuery dbquery = new DSQuery();
            dbquery.query = @" insert into Employee 
                              ([Name]
                              ,[Age]
                              ,[Salary]
                              ,[MaritalStatus]
                              ,[Location]) values(@Name,@Age,@Salary,@MaritalStatus,@Location);";
            dbquery.parameters.Add("Name", emp.Name);
            dbquery.parameters.Add("Age", emp.Age);
            dbquery.parameters.Add("Salary", emp.Salary);
            dbquery.parameters.Add("MaritalStatus", emp.MaritalStatus);
            dbquery.parameters.Add("Location", emp.Location);
            result = DBManager.internalExecute(dbquery);
            return result;
        }

        private string getCountDBQuery()
        {
            return "  SELECT COUNT(Id) AS COUNT FROM Employee EMPLOYEE";
        }

    }
}