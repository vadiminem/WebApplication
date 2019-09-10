using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
//using Dapper;
using Microsoft.IdentityModel.Protocols;
using WebApplication.Models;

namespace WebApplication1.Models
{
    public class ResultContext
    {

        string connectionString = "";
        public void Create(SomeObject someObject)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Result";
            }
        }
    }
}
