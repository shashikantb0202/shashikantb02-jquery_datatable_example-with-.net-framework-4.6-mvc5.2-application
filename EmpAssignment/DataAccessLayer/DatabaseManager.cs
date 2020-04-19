using EmpAssignment.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EmpAssignment.DataAccessLayer
{
    public class DatabaseManager
    {
       
        string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        private static DatabaseManager instance;
        public static DatabaseManager sharedDatabaseManagerinstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DatabaseManager();
                }
                return instance;
            }
        }

        public DataSet internalExecuteSelectQueryAndReturnDataSet(DSQuery query)
        {

            using (SqlConnection connection = new SqlConnection(cs))
            {

                SqlCommand command = connection.CreateCommand();
                command.CommandText = query.query;
                SetParametersToCommand(query, command);
                DataSet dataSet = new DataSet();
                try
                {
                    if (command.Connection.State != ConnectionState.Open)
                    {
                        command.Connection.Open();
                    }
                    MapSqlCommandToDataSetSync(command, dataSet);
                }
                catch (Exception exception)
                {
                    Console.Write(exception);
                    throw (exception);
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
                return dataSet;
            }
            
        }



        public bool internalExecute(DSQuery query)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                int roDS_affected = 0;
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query.query, connection);
                    SetParametersToCommand(query, command);
                    roDS_affected = command.ExecuteNonQuery();
                }
                catch (Exception exception)
                {
                    Console.Write(exception);
                    throw (exception);
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }

                return roDS_affected != 0;
            }
        }










        protected void SetParametersToCommand(DSQuery query, SqlCommand command)
        {
            foreach (var key in query.parameters.Keys)
            {
                var paramkey = "@" + key;
                if (this.isPrimptive(query.parameters[key]))
                {
                    if (query.parameters[key] == null)
                        command.Parameters.AddWithValue(paramkey, DBNull.Value);
                    else
                        command.Parameters.AddWithValue(paramkey, query.parameters[key]);
                }
            }
        }
        protected void MapSqlCommandToDataSetSync(SqlCommand command, DataSet dataSet)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = command;
            dataAdapter.Fill(dataSet);
        }

        private bool IsList(object o)
        {
            if (o == null) return false;
            return o is IList &&
                   o.GetType().IsGenericType &&
                   o.GetType().GetGenericTypeDefinition().IsAssignableFrom(typeof(List<>));
        }
        private bool IsDictionary(object o)
        {
            if (o == null) return false;
            return o is IDictionary &&
                   o.GetType().IsGenericType &&
                   o.GetType().GetGenericTypeDefinition().IsAssignableFrom(typeof(Dictionary<,>));
        }
        protected bool isPrimptive(object obj)
        {
            if (this.IsList(obj) || this.IsDictionary(obj))
                return false;
            return true;
        }
    }
}