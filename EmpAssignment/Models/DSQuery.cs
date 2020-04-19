
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace EmpAssignment.Models
{
    public class DSQuery
    {
        public String query { get; set; }
        public Dictionary<String, Object> parameters { get; set; }

        public SqlConnection connection { get; set; }

     
        /*-------------------------------*/
        public DSQuery()
        {
            this.parameters = new Dictionary<String, Object>();
        }


        public DSQuery(string query)
        {

            this.query = query;
            this.parameters = new Dictionary<String, Object>();
        }
        public DSQuery(string query, Dictionary<String, Object> parameters)
        {

            this.query = query;
            this.parameters = parameters;
        }
       
    }
}